





namespace BrightFocus.Application.Query.Task.GetTaskDetail;

public class GetTaskDetailCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    ITaskListQuery taskListQuery,
    ITaskDetailQuery taskDetailQuery,
    MPaginationConfig mPaginationConfig) :
    BaseCommandHandler(
        mapper,
        tokenInfo,
        authenticateRepository,
        logger,
        mediator,
        mPaginationConfig),
    IRequestHandler<GetTaskDetailCommand, MResponse<TaskListDto>>
{
    public async Task<MResponse<TaskListDto>> Handle(GetTaskDetailCommand request, CancellationToken cancellationToken)
    {
        MResponse<TaskListDto> result = new();

        TaskListEntity? taskDetail = await taskListQuery.GetByGuidAsync(request.TaskId);

        if (taskDetail is null)
        {
            result.StatusCode = StatusCodes.Status404NotFound;
            result.AddErrorMessage(nameof(AllTaskError.NotFound));
            return result;
        }


        List<TaskDetailEntity>? taskDetailByParent = await taskDetailQuery.GetTaskDetailByTaskNoAsync(taskDetail.EntityId);

        TaskListDto data = Mapper.Map<TaskListEntity, TaskListDto>(taskDetail);
        data.TaskDetails = taskDetailByParent is not null ? Mapper.Map<IEnumerable<TaskDetailEntity>, IEnumerable<TaskDetailDto>>(taskDetailByParent) : [];
        result.Result = data;
        return result;
    }


}
