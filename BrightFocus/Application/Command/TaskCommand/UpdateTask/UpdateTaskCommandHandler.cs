namespace BrightFocus.Application.Command.TaskCommand.UpdateTask;

public class UpdateTaskCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    ITaskListRepository taskListRepository,
    ITaskListQuery taskListQuery,
    ITaskDetailRepository taskDetailRepository,
    ITaskDetailQuery taskDetailQuery,
    IDeliveryWarehouseRepository deliveryWarehouseRepository,
    IDeliveryWarehouseQuery deliveryWarehouseQuery,
    IMJsonSerializeService mJsonSerializeService,
    IFileStorageService fileStorageService
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<UpdateTaskCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();

        TaskListEntity? existTask = await taskListQuery.GetByGuidAsync(request.EntityId ?? Guid.Empty);
        if (existTask is null)
        {
            result.StatusCode = StatusCodes.Status404NotFound;
            result.AddErrorMessage(nameof(AllTaskError.NotFound));
            return result;
        }

        _ = Mapper.Map(request, existTask);

        if (request.File != null)
        {
            existTask.FileUrl = await fileStorageService.SaveFileAsync(request.File, "uploads");
        }

        IEnumerable<TaskDetailDto> taskDetails = ParseTaskDetails(request.TaskDetails);

        await taskListRepository.ExecuteTransactionAsync(async () =>
        {
            await UpdateTaskAsync(existTask, taskDetails, request);

            result.Result = true;
            return result;
        });

        return result;
    }

    private IEnumerable<TaskDetailDto> ParseTaskDetails(string? taskDetailsJson)
    {
        return string.IsNullOrEmpty(taskDetailsJson)
            ? []
            : mJsonSerializeService.Deserialize<IEnumerable<TaskDetailDto>>(taskDetailsJson) ?? Enumerable.Empty<TaskDetailDto>();
    }

    private async Task UpdateTaskAsync(TaskListEntity existTask, IEnumerable<TaskDetailDto> taskDetails, UpdateTaskCommand request)
    {
        _ = taskListRepository.Update(existTask);

        if (taskDetails.Any())
        {
            List<TaskDetailEntity> existingTaskDetails = await taskDetailQuery.GetTaskDetailByTaskNoAsync(request.EntityId ?? Guid.Empty) ?? [];
            await UpdateTaskDetails(existingTaskDetails, taskDetails.ToList(), existTask.EntityId);

            await UpdateDeliveryWarehouses(taskDetails, existTask.EntityId, existTask.Warehouse ?? string.Empty);
        }

        await CommitChangesAsync();
    }

    private async Task UpdateTaskDetails(
        List<TaskDetailEntity> existingTaskDetails,
        List<TaskDetailDto> taskDetails,
        Guid taskId)
    {
        HashSet<Guid?> requestDetailIds = taskDetails.Select(d => d.EntityId).ToHashSet();

        List<TaskDetailEntity> toDelete = existingTaskDetails
            .Where(detail => !requestDetailIds.Contains(detail.EntityId))
            .ToList();
        if (toDelete.Count != 0)
        {
            _ = await Mediator.Send(new DeleteTaskDetailCommand
            {
                TaskDetailIds = toDelete.Select(x => x.EntityId).ToList()
            });
        }

        foreach (TaskDetailDto detailDto in taskDetails)
        {
            TaskDetailEntity? matchedDetail = existingTaskDetails.FirstOrDefault(x => x.EntityId == detailDto.EntityId);
            if (matchedDetail != null)
            {
                _ = Mapper.Map(detailDto, matchedDetail);
                matchedDetail.TaskId = taskId;
                _ = taskDetailRepository.Update(matchedDetail);
            }
            else
            {
                TaskDetailEntity newDetail = Mapper.Map<TaskDetailEntity>(detailDto);
                newDetail.TaskId = taskId;
                _ = taskDetailRepository.Add(newDetail);
            }
        }
    }

    private async Task UpdateDeliveryWarehouses(
        IEnumerable<TaskDetailDto> taskDetails,
        Guid taskId,
        string toWarehouse)
    {
        List<DeliveryWarehouseEntity> existingWarehouses = await deliveryWarehouseQuery.GetByConditionAsync(x => x.TaskId == taskId);

        List<DeliveryWarehouseEntity> deliveryWarehouses = GenerateDeliveryWarehouses(taskDetails, taskId, toWarehouse)
            .Select(Mapper.Map<DeliveryWarehouseDto, DeliveryWarehouseEntity>)
            .ToList();

        foreach (DeliveryWarehouseEntity? warehouse in deliveryWarehouses)
        {
            DeliveryWarehouseEntity? existingWarehouse = existingWarehouses.FirstOrDefault(w =>
                w.FromWarehouse == warehouse.FromWarehouse &&
                w.ToWarehouse == warehouse.ToWarehouse &&
                w.ProductCode == warehouse.ProductCode &&
                w.Employee == warehouse.Employee);

            if (existingWarehouse != null)
            {
                _ = Mapper.Map(warehouse, existingWarehouse);
                _ = deliveryWarehouseRepository.Update(existingWarehouse);
            }
            else
            {
                _ = deliveryWarehouseRepository.Add(warehouse);
            }
        }

        HashSet<(string FromWarehouse, string ToWarehouse)> currentPairs = deliveryWarehouses
            .Select(dw => (dw.FromWarehouse, dw.ToWarehouse))
            .ToHashSet();

        List<DeliveryWarehouseEntity> toDelete = existingWarehouses
            .Where(w => !currentPairs.Contains((w.FromWarehouse, w.ToWarehouse)))
            .ToList();

        foreach (DeliveryWarehouseEntity? warehouse in toDelete)
        {
            _ = await deliveryWarehouseRepository.DeleteAsync(warehouse);
        }
    }

    private static IEnumerable<DeliveryWarehouseDto> GenerateDeliveryWarehouses(
       IEnumerable<TaskDetailDto> taskDetails,
       Guid taskId,
       string toWarehouse)
    {
        List<TaskDetailDto> taskDetailsList = taskDetails.ToList();
        if (taskDetailsList.Count == 0)
        {
            return [];
        }

        return taskDetailsList
            .Skip(1)
            .Select(td => td.Warehouse)
            .Distinct()
            .SelectMany(fromWarehouse =>
                taskDetailsList.Where(td => td.Warehouse == fromWarehouse)
                    .GroupBy(td => new { td.ProductName, td.Material, td.Employee })
                    .Select(group => new DeliveryWarehouseDto
                    {
                        FromWarehouse = fromWarehouse,
                        ToWarehouse = toWarehouse,
                        ProductCode = group.Key.Material,
                        ProductName = group.Key.ProductName,
                        Quantity = group.Sum(td => td.Quantity),
                        Employee = group.Key.Employee,
                        DeliveryType = DeliveryType.Waiting,
                        TaskId = taskId
                    }))
            .GroupBy(dw => new { dw.FromWarehouse, dw.ToWarehouse, dw.ProductCode, dw.Employee })
            .Select(group => new DeliveryWarehouseDto
            {
                FromWarehouse = group.Key.FromWarehouse,
                ToWarehouse = group.Key.ToWarehouse,
                ProductCode = group.Key.ProductCode,
                ProductName = group.First().ProductName,
                Quantity = group.Sum(dw => dw.Quantity),
                Employee = group.Key.Employee,
                DeliveryType = DeliveryType.Waiting,
                TaskId = taskId
            });
    }

    private async Task CommitChangesAsync()
    {
        _ = await taskListRepository.UnitOfWork.SaveChangesAsync();
        _ = await taskDetailRepository.UnitOfWork.SaveChangesAsync();
        _ = await deliveryWarehouseRepository.UnitOfWork.SaveChangesAsync();
    }
}
