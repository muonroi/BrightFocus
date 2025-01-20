namespace BrightFocus.Application.Command.Dashboard
{
    public class DeleteTaskCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        IDashboardRepository dashboardRepository,
        IDashboardQuery dashboardQuery
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<DeleteTaskCommand, MResponse<bool>>
    {
        public async Task<MResponse<bool>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            MResponse<bool> result = new();
            DashboardEntity? taskDelete = await dashboardQuery.GetByGuidAsync(request.EntityId);
            if (taskDelete == null)
            {
                result.AddErrorMessage("Task not found");
                return result;
            }
            _ = dashboardRepository.DeleteAsync(taskDelete);
            _ = await dashboardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            result.Result = true;
            return result;
        }
    }
}