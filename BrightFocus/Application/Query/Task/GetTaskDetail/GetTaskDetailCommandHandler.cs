namespace BrightFocus.Application.Query.Task.GetTaskDetail
{
    public class GetTaskDetailCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        ITaskListQuery taskListQuery,
        MPaginationConfig mPaginationConfig) :
        BaseCommandHandler(
            mapper,
            tokenInfo,
            authenticateRepository,
            logger,
            mediator,
            mPaginationConfig),
        IRequestHandler<GetTaskDetailCommand, MResponse<TaskDetailDto>>
    {
        public async Task<MResponse<TaskDetailDto>> Handle(GetTaskDetailCommand request, CancellationToken cancellationToken)
        {
            MResponse<TaskDetailDto> result = new();

            TaskList? taskDetail = await taskListQuery.GetByGuidAsync(request.TaskId);

            if (taskDetail is null)
            {
                result.StatusCode = StatusCodes.Status404NotFound;
                result.AddErrorMessage(nameof(AllTaskError.NotFound));
                return result;
            }

            TaskDetailDto data = Mapper.Map<TaskList, TaskDetailDto>(taskDetail);
            result.Result = data;
            return result;
        }
    }
}
