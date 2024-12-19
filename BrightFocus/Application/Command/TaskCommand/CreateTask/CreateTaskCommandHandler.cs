



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
    IMJsonSerializeService mJsonSerializeService
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
            taskEntity.TaskType = TaskType.Green;
            ImportMaterialWarehouseCommand importData = new()
            {
                File = request.File
            };
            _ = await Mediator.Send(importData, cancellationToken);

            _ = taskListRepository.Add(taskEntity);

            _ = await taskListRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        IEnumerable<TaskDetailDto> taskDetails = ParseTaskDetails(request.TaskDetails, cancellationToken);

        await SaveTaskAsync(taskEntity, taskDetails, request);

        return new MResponse<bool> { Result = true };
    }

    private IEnumerable<TaskDetailDto> ParseTaskDetails(string? taskDetailsJson, CancellationToken cancellationToken)
    {
        IEnumerable<TaskDetailDto> taskDetails = string.IsNullOrEmpty(taskDetailsJson)
            ? []
            : mJsonSerializeService.Deserialize<IEnumerable<TaskDetailDto>>(taskDetailsJson) ?? [];

        return taskDetails;
    }

    private async Task SaveTaskAsync(TaskListEntity taskEntity, IEnumerable<TaskDetailDto> taskDetails, CreateTaskCommand request)
    {
        _ = taskListRepository.Add(taskEntity);

        await CommitChangesAsync();
    }

    private async Task CommitChangesAsync()
    {
        _ = await taskListRepository.UnitOfWork.SaveChangesAsync();
        _ = await taskDetailRepository.UnitOfWork.SaveChangesAsync();
        _ = await deliveryWarehouseRepository.UnitOfWork.SaveChangesAsync();
    }

}
