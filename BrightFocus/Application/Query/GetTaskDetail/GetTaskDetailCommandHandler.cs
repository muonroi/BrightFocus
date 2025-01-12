

namespace BrightFocus.Application.Query.GetTaskDetail
{
    public class GetTaskDetailCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        ITaskProductionQuery taskProductionQuery
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<GetTaskDetailCommand, MResponse<ProductionTaskResponse>>
    {
        public async Task<MResponse<ProductionTaskResponse>> Handle(GetTaskDetailCommand request, CancellationToken cancellationToken)
        {
            MResponse<ProductionTaskResponse> result = new();
            ProductionTaskResponse? taskProductionData = await taskProductionQuery.GetProductionTaskById(request.EntityId);
            if (taskProductionData is null)
            {
                return result;
            }
            result.Result = taskProductionData;
            return result;
        }
    }
}