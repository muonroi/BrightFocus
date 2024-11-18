namespace BrightFocus.Application.Command.TaskCommand.UpdateTask;

public class UpdateTaskCommandHandler(IMapper mapper, MAuthenticateInfoContext tokenInfo, IAuthenticateRepository authenticateRepository, Serilog.ILogger logger, IMediator mediator, MPaginationConfig paginationConfig,
    ITaskListRepository taskListRepository,
    ITaskListQuery taskListQuery,
    ITaskDetailRepository taskDetailRepository,
    ITaskDetailQuery taskDetailQuery) :
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

        TaskListEntity? existTask = await taskListQuery.GetByGuidAsync(request.TaskId);
        if (existTask is null)
        {
            result.StatusCode = StatusCodes.Status404NotFound;
            result.AddErrorMessage(nameof(AllTaskError.NotFound));
            return result;
        }

        _ = Mapper.Map(request, existTask);

        await taskListRepository.ExecuteTransactionAsync(async () =>
        {
            _ = taskListRepository.Update(existTask);

            if (request.TaskDetails is not null)
            {
                List<TaskDetailEntity>? taskDetails = await taskDetailQuery.GetTaskDetailByTaskNoAsync(request.TaskId);

                if (taskDetails is null)
                {
                    result.StatusCode = StatusCodes.Status404NotFound;
                    result.AddErrorMessage(nameof(AllTaskError.NotFound));
                    return result;
                }

                foreach (TaskDetailEntity taskDetail in taskDetails)
                {
                    TaskDetailDto? matchedDetail = request.TaskDetails.FirstOrDefault(x => x.EntityId == taskDetail.EntityId);
                    if (matchedDetail is not null)
                    {
                        _ = Mapper.Map(matchedDetail, taskDetail);
                        _ = taskDetailRepository.Update(taskDetail);
                    }
                }
            }

            _ = await taskDetailRepository.UnitOfWork.SaveChangesAsync();
            _ = await taskListRepository.UnitOfWork.SaveChangesAsync();

            result.Result = true;
            return result;
        });

        return result;
    }
}
