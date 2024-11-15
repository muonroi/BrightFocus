namespace BrightFocus.Application.Command.TaskCommand.DeleteTask;

public class DeleteTaskCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    ITaskListRepository taskListRepository,
    ITaskListQuery taskListQuery,
    ITaskDetailRepository taskDetailRepository,
    ITaskDetailQuery taskDetailQuery)
            : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<DeleteTaskCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();

        IEnumerable<TaskListEntity> allTasks = await taskListQuery.GetTaskByGuidsAsync(request.TaskIds);
        List<Guid> foundTaskIds = allTasks.Select(t => t.EntityId).ToList();
        List<Guid> notFoundIds = request.TaskIds.Except(foundTaskIds).ToList();

        if (notFoundIds.Count != 0)
        {
            result.StatusCode = StatusCodes.Status404NotFound;
            result.AddErrorMessage($"{notFoundIds.Count} tasks not found.");
            return result;
        }

        await taskListRepository.ExecuteTransactionAsync(async () =>
        {
            List<TaskDetailEntity> taskDetails = await taskDetailQuery.GetTaskDetailsByTaskIdsAsync(foundTaskIds);
            await taskDetailRepository.DeleteBatchAsync(taskDetails);
            await taskListRepository.DeleteBatchAsync(allTasks);

            await taskListRepository.UnitOfWork.SaveChangesAsync();
            await taskDetailRepository.UnitOfWork.SaveChangesAsync();

            result.Result = true;
            return result;
        });

        return result;
    }
}
