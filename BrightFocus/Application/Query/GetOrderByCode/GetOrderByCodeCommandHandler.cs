namespace BrightFocus.Application.Query.GetOrderByCode
{
    public class GetOrderByCodeCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        IOderQuery oderQuery
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<GetOrderByCodeCommand, MResponse<IEnumerable<TaskMaterialResponse>>>
    {
        public async Task<MResponse<IEnumerable<TaskMaterialResponse>>> Handle(GetOrderByCodeCommand request, CancellationToken cancellationToken)
        {
            MResponse<IEnumerable<TaskMaterialResponse>> result = new();
            IEnumerable<TaskMaterialResponse> orderResult = await oderQuery.GetOrderByCode(request.OrderNo);
            result.Result = orderResult;
            return result;
        }
    }
}