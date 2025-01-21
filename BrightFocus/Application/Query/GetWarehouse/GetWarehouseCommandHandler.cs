namespace BrightFocus.Application.Query.GetWarehouse
{
    public class GetWarehouseCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        ITaskImportQuery taskImportQuery
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<GetWarehouseCommand, MResponse<MPagedResult<TaskMaterialResponse>>>
    {
        public async Task<MResponse<MPagedResult<TaskMaterialResponse>>> Handle(GetWarehouseCommand request, CancellationToken cancellationToken)
        {
            MResponse<MPagedResult<TaskMaterialResponse>> result = new();

            MPagedResult<TaskMaterialResponse> data = await taskImportQuery.GetWarehouseDataUsesAsync(
                request.ProductName,
                request.IngredientName,
                request.StructureName,
                request.CharacteristicName,
                request.PageIndex,
                PaginationConfig.DefaultPageSize
            );
            result.Result = data;
            return result;
        }
    }
}