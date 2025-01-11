namespace BrightFocus.Application.Query.GetDashboardTask
{
    public class GetDashboardTaskCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        IDashboardQuery dashboardQuery
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<GetDashboardTaskCommand, MResponse<MPagedResult<DashboardResponseModel>>>
    {
        public async Task<MResponse<MPagedResult<DashboardResponseModel>>> Handle(GetDashboardTaskCommand request, CancellationToken cancellationToken)
        {
            MResponse<MPagedResult<DashboardResponseModel>> result = new();
            MPagedResult<DashboardResponseModel> dashboards = await dashboardQuery.GetDashboardData(PaginationConfig.DefaultPageIndex, PaginationConfig.DefaultPageSize);
            result.Result = dashboards;
            return result;
        }
    }
}
