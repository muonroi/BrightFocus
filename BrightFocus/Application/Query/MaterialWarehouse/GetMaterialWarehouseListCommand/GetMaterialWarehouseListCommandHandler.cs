

namespace BrightFocus.Application.Query.MaterialWarehouse.GetMaterialWarehouseListCommand
{
    public class GetMaterialWarehouseListCommandHandler(IMapper mapper, MAuthenticateInfoContext tokenInfo, IAuthenticateRepository authenticateRepository, Serilog.ILogger logger, IMediator mediator, MPaginationConfig paginationConfig,
        IMaterialWarehouseQuery materialWarehouseQuery) :
        BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<GetMaterialWarehouseListCommand, MResponse<MPagedResult<MaterialWarehousesDto>>>
    {
        public async Task<MResponse<MPagedResult<MaterialWarehousesDto>>> Handle(GetMaterialWarehouseListCommand request, CancellationToken cancellationToken)
        {

            MResponse<MPagedResult<MaterialWarehousesDto>> pagedResult = await materialWarehouseQuery.GetMaterialListPagingAsync(
                 request.Page,
                 DefaultPageSize,
                 request.Search,
                 request.SortBy,
                 request.SortOrder,
                 request.ProductName,
                 request.Material,
                 request.Quantification,
                 request.Color,
                 request.Characteristic,
                 request.Warehouse);
            
            if (pagedResult.IsOK)
            {
                return pagedResult;
            }

            pagedResult.StatusCode = StatusCodes.Status404NotFound;
            pagedResult.AddErrorMessage(nameof(AllTaskError.NotFound));
            return pagedResult;
        }
    }
}
