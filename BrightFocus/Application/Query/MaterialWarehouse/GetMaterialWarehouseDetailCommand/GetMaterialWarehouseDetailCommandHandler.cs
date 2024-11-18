

namespace BrightFocus.Application.Query.MaterialWarehouse.GetMaterialWarehouseDetailCommand
{
    public class GetMaterialWarehouseDetailCommandHandler(
        IMapper mapper, MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger, IMediator mediator,
        MPaginationConfig paginationConfig,
        IMaterialWarehouseQuery materialWarehouseQuery) :
        BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<GetMaterialWarehouseDetailCommand, MResponse<MaterialWarehousesDto>>
    {
        public async Task<MResponse<MaterialWarehousesDto>> Handle(GetMaterialWarehouseDetailCommand request, CancellationToken cancellationToken)
        {
            MResponse<MaterialWarehousesDto> result = new();
            MaterialWarehouseEntity? materialWarehouse = await materialWarehouseQuery.GetByGuidAsync(request.MaterialWarehouseId);
            if (materialWarehouse is null)
            {
                result.StatusCode = StatusCodes.Status404NotFound;
                result.AddErrorMessage(nameof(AllTaskError.NotFound));
                return result;
            }
            result.Result = Mapper.Map<MaterialWarehouseEntity, MaterialWarehousesDto>(materialWarehouse);
            return result;
        }
    }
}
