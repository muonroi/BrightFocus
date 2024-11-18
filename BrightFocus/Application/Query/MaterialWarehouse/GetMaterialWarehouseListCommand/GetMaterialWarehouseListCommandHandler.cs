

namespace BrightFocus.Application.Query.MaterialWarehouse.GetMaterialWarehouseListCommand
{
    public class GetMaterialWarehouseListCommandHandler(IMapper mapper, MAuthenticateInfoContext tokenInfo, IAuthenticateRepository authenticateRepository, Serilog.ILogger logger, IMediator mediator, MPaginationConfig paginationConfig,
        IMaterialWarehouseQuery materialWarehouseQuery) :
        BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<GetMaterialWarehouseListCommand, MResponse<MPagedResult<MaterialWarehousesDto>>>
    {
        public async Task<MResponse<MPagedResult<MaterialWarehousesDto>>> Handle(GetMaterialWarehouseListCommand request, CancellationToken cancellationToken)
        {

            MResponse<MPagedResult<MaterialWarehousesDto>>? pagedResult = await materialWarehouseQuery.GetMaterialListPagingAsync(
                request.Page, request.PageSize ?? DefaultPageSize, request.Search, request.SortBy, request.SortOrder);
            if (!pagedResult.IsOK)
            {
                pagedResult.StatusCode = StatusCodes.Status404NotFound;
                pagedResult.AddErrorMessage(nameof(AllTaskError.NotFound));
                return pagedResult;
            }
            return pagedResult;
        }
    }
}
