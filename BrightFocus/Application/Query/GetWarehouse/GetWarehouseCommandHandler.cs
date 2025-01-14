namespace BrightFocus.Application.Query.GetWarehouse
{
    public class GetWarehouseCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        ITaskProductionQuery taskProductionQuery,
        ITaskImportExportQuery taskImportExportQuery,
        ITaskCustomerQuery taskCustomerQuery,
        ITaskOrderQuery taskOrderQuery
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<GetWarehouseCommand, MResponse<IEnumerable<TaskMaterialResponse>>>
    {
        public Task<MResponse<IEnumerable<TaskMaterialResponse>>> Handle(GetWarehouseCommand request, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}