

namespace BrightFocus.Application.Command.TaskCommand.UpdateTask;

public class UpdateTaskCommandHandler(IMapper mapper, MAuthenticateInfoContext tokenInfo, IAuthenticateRepository authenticateRepository, Serilog.ILogger logger, IMediator mediator, MPaginationConfig paginationConfig,
    ITaskListRepository taskListRepository,
    ITaskListQuery taskListQuery,
    ITaskDetailRepository taskDetailRepository,
    ITaskDetailQuery taskDetailQuery,
    IDeliveryWarehouseRepository deliveryWarehouseRepository,
    IDeliveryWarehouseQuery deliveryWarehouseQuery,
    IWebHostEnvironment webHostEnvironment) :
    BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<UpdateTaskCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();

        TaskListEntity taskEntity = Mapper.Map<TaskListEntity>(request);
        if (!taskEntity.IsValid())
        {
            result.StatusCode = StatusCodes.Status400BadRequest;
            result.AddResultFromErrorList(taskEntity.ErrorMessages);
            return result;
        }
        if (request.EntityId is null)
        {
            result.StatusCode = StatusCodes.Status400BadRequest;
            result.AddResultFromErrorList(taskEntity.ErrorMessages);
            return result;
        }

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
            string savedFilePath = await SaveFileAsync(request.File);
            if (!string.IsNullOrEmpty(savedFilePath))
            {
                existTask.FileUrl = savedFilePath;
            }
        }

        await taskListRepository.ExecuteTransactionAsync(async () =>
        {
            _ = taskListRepository.Update(existTask);

            if (request.TaskDetails is not null)
            {
                List<TaskDetailEntity>? existingTaskDetails = await taskDetailQuery.GetTaskDetailByTaskNoAsync(request.EntityId ?? Guid.Empty);
                existingTaskDetails ??= [];

                List<Guid?> requestDetailIds = request.TaskDetails.Select(d => d.EntityId).ToList();

                List<TaskDetailEntity> toDelete = existingTaskDetails
                    .Where(detail => !requestDetailIds.Contains(detail.EntityId))
                    .ToList();

                foreach (TaskDetailEntity detailToDelete in toDelete)
                {
                    _ = await taskDetailRepository.DeleteAsync(detailToDelete);
                }

                foreach (TaskDetailDto detailDto in request.TaskDetails)
                {
                    TaskDetailEntity? matchedDetail = existingTaskDetails.FirstOrDefault(x => x.EntityId == detailDto.EntityId);

                    if (matchedDetail is not null)
                    {
                        _ = Mapper.Map(detailDto, matchedDetail);
                        matchedDetail.TaskId = existTask.EntityId;
                        _ = taskDetailRepository.Update(matchedDetail);
                    }
                    else
                    {
                        TaskDetailEntity newDetail = Mapper.Map<TaskDetailEntity>(detailDto);
                        newDetail.TaskId = existTask.EntityId;
                        _ = taskDetailRepository.Add(newDetail);
                    }
                }

                await UpdateDeliveryWarehouses(request.TaskDetails, existTask.EntityId, existTask.Warehouse ?? string.Empty);
            }

            _ = await taskDetailRepository.UnitOfWork.SaveChangesAsync();
            _ = await taskListRepository.UnitOfWork.SaveChangesAsync();

            result.Result = true;
            return result;
        });

        return result;
    }


    private async Task<string> SaveFileAsync(IFormFile file)
    {
        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");

        if (!Directory.Exists(uploadsFolder))
        {
            _ = Directory.CreateDirectory(uploadsFolder);
        }

        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);

        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (FileStream fileStream = new(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return Path.Combine("uploads", uniqueFileName);
    }


    private async Task UpdateDeliveryWarehouses(IEnumerable<TaskDetailDto> taskDetails, Guid taskId, string toWarehouse)
    {
        List<DeliveryWarehouseEntity> existingWarehouses = await deliveryWarehouseQuery.GetByConditionAsync(x => x.TaskId == taskId);
        List<(string FromWarehouse, string ToWarehouse)> currentWarehousePairs = DeliveryWarehouseDto.GetWarehousePairs(taskDetails);

        foreach (DeliveryWarehouseEntity existingWarehouse in existingWarehouses)
        {
            if (!currentWarehousePairs.Any(pair =>
                pair.FromWarehouse == existingWarehouse.FromWarehouse &&
                pair.ToWarehouse == existingWarehouse.ToWarehouse))
            {
                _ = await deliveryWarehouseRepository.DeleteAsync(existingWarehouse);
            }
        }

        List<DeliveryWarehouseDto> deliveryWarehouses = GenerateDeliveryWarehousesForPair(taskDetails, taskId, toWarehouse).ToList();

        foreach (DeliveryWarehouseDto warehouseDto in deliveryWarehouses)
        {
            DeliveryWarehouseEntity? existingWarehouse = existingWarehouses.FirstOrDefault(ew =>
                ew.FromWarehouse == warehouseDto.FromWarehouse &&
                ew.ToWarehouse == warehouseDto.ToWarehouse &&
                ew.ProductCode == warehouseDto.ProductCode &&
                ew.Employee == warehouseDto.Employee);

            if (existingWarehouse is not null)
            {
                _ = Mapper.Map(warehouseDto, existingWarehouse);
                _ = deliveryWarehouseRepository.Update(existingWarehouse);
            }
            else
            {
                DeliveryWarehouseEntity newWarehouse = Mapper.Map<DeliveryWarehouseEntity>(warehouseDto);
                _ = deliveryWarehouseRepository.Add(newWarehouse);
            }
        }
    }

    private static IEnumerable<DeliveryWarehouseDto> GenerateDeliveryWarehousesForPair(IEnumerable<TaskDetailDto> taskDetails, Guid taskId, string toWarehouse)
    {
        List<TaskDetailDto> taskDetailsList = taskDetails.ToList();

        if (taskDetailsList.Count == 0)
        {
            return [];
        }

        IEnumerable<string> fromWarehouses = taskDetailsList.Skip(1).Select(td => td.Warehouse).Distinct();

        List<DeliveryWarehouseDto> deliveryWarehouseDtos = fromWarehouses
            .SelectMany(fromWarehouse => taskDetailsList
                .Where(td => td.Warehouse == fromWarehouse)
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
            .ToList();

        IEnumerable<DeliveryWarehouseDto> distinctDeliveryWarehouses = deliveryWarehouseDtos
            .GroupBy(dw => new
            {
                dw.FromWarehouse,
                dw.ToWarehouse,
                dw.ProductCode,
                dw.Employee
            })
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

        return distinctDeliveryWarehouses;
    }
}
