

namespace BrightFocus.Application.Command.TaskCommand.CreateTask;

public class CreateTaskCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    ITaskListRepository taskListRepository,
    ITaskDetailRepository taskDetailRepository,
    IDeliveryWarehouseRepository deliveryWarehouseRepository,
    IMJsonSerializeService mJsonSerializeService,
    IFileStorageService fileStorageService
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<CreateTaskCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();

        TaskListEntity taskEntity = Mapper.Map<CreateTaskCommand, TaskListEntity>(request);
        if (!taskEntity.IsValid())
        {
            result.StatusCode = StatusCodes.Status400BadRequest;
            result.AddResultFromErrorList(taskEntity.ErrorMessages);
            return result;
        }

        if (request.File != null)
        {
            taskEntity.FileUrl = await fileStorageService.SaveFileAsync(request.File, "uploads");
        }

        IEnumerable<TaskDetailDto> taskDetails = ParseTaskDetails(request.TaskDetails);

        await SaveTaskAsync(taskEntity, taskDetails, request);

        return new MResponse<bool> { Result = true };
    }

    private IEnumerable<TaskDetailDto> ParseTaskDetails(string? taskDetailsJson)
    {
        return string.IsNullOrEmpty(taskDetailsJson)
            ? []
            : mJsonSerializeService.Deserialize<IEnumerable<TaskDetailDto>>(taskDetailsJson) ?? Enumerable.Empty<TaskDetailDto>();
    }

    private async Task SaveTaskAsync(TaskListEntity taskEntity, IEnumerable<TaskDetailDto> taskDetails, CreateTaskCommand request)
    {
        _ = taskListRepository.Add(taskEntity);

        if (taskDetails.Any())
        {
            await ProcessTaskDetailsAndDeliveryWarehouses(taskDetails.ToList(), taskEntity.EntityId, request.Warehouse);
        }

        await CommitChangesAsync();
    }

    private async Task ProcessTaskDetailsAndDeliveryWarehouses(
     IEnumerable<TaskDetailDto> taskDetailsRequest,
     Guid taskId,
     string toWarehouse)
    {
        List<TaskDetailEntity> taskDetails = MapTaskDetails(taskDetailsRequest, taskId);
        List<DeliveryWarehouseEntity> deliveryWarehouses = MapDeliveryWarehouses(taskDetailsRequest, taskId, toWarehouse);

        _ = await taskDetailRepository.AddBatchAsync(taskDetails);
        _ = await deliveryWarehouseRepository.AddBatchAsync(deliveryWarehouses);
    }

    private List<TaskDetailEntity> MapTaskDetails(IEnumerable<TaskDetailDto> taskDetailsRequest, Guid taskId)
    {
        return taskDetailsRequest.Select(td =>
        {
            TaskDetailEntity entity = Mapper.Map<TaskDetailDto, TaskDetailEntity>(td);
            entity.TaskId = taskId;
            return entity;
        }).ToList();
    }

    private List<DeliveryWarehouseEntity> MapDeliveryWarehouses(
        IEnumerable<TaskDetailDto> taskDetailsRequest,
        Guid taskId,
        string toWarehouse)
    {
        return GenerateDeliveryWarehouses(taskDetailsRequest, taskId, toWarehouse)
            .Select(Mapper.Map<DeliveryWarehouseDto, DeliveryWarehouseEntity>)
            .ToList();
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
