namespace BrightFocus.Application.Query.Task.GetTaskList
{
    public class GetTaskListCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        ITaskListQuery taskListQuery,
        MPaginationConfig mPaginationConfig)
                : BaseCommandHandler(
                    mapper,
                    tokenInfo,
                    authenticateRepository,
                    logger,
                    mediator,
                    mPaginationConfig),
        IRequestHandler<GetTaskListCommand, MResponse<MPagedResult<TaskListDto>>>
    {
        public async Task<MResponse<MPagedResult<TaskListDto>>> Handle(GetTaskListCommand request, CancellationToken cancellationToken)
        {
            MResponse<MPagedResult<TaskListDto>> result = new();
            MResponse<MPagedResult<TaskListDto>> data = await taskListQuery.GetTaskListPagingAsync(request.Page, DefaultPageSize, request.Search, request.SortBy, request.SortOrder);
            if (!data.IsOK)
            {
                result.StatusCode = StatusCodes.Status404NotFound;
                result.AddErrorMessage(nameof(AllTaskError.NotFound));
                return result;
            }
            result.Result = data.Result;
            return result;
        }
    }
}
