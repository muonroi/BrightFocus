





namespace BrightFocus.Application.Command.MaterialWarehouse.UpdateMaterialWarehouse;

public class UpdateMaterialWarehouseCommandHandler(IMapper mapper, MAuthenticateInfoContext tokenInfo, IAuthenticateRepository authenticateRepository, Serilog.ILogger logger, IMediator mediator, MPaginationConfig paginationConfig,
    IMaterialWarehouseRepository materialWarehouseRepository,
    IMaterialWarehouseQuery materialWarehouseQuery) :
    BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<UpdateMaterialWarehouseCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(UpdateMaterialWarehouseCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();

        MaterialWarehouseEntity materialWarehouse = Mapper.Map<MaterialWarehouseEntity>(request);

        if (!materialWarehouse.IsValid())
        {
            result.StatusCode = StatusCodes.Status400BadRequest;
            result.AddResultFromErrorList(materialWarehouse.ErrorMessages);
            return result;
        }

        MaterialWarehouseEntity? existMaterialEntity = await materialWarehouseQuery.GetByGuidAsync(request.MaterialWarehouseId);
        if (existMaterialEntity is null)
        {
            result.StatusCode = StatusCodes.Status404NotFound;
            result.AddErrorMessage(nameof(AllTaskError.NotFound));
            return result;
        }

        bool isDuplicateProductCode = await materialWarehouseQuery.ExistsAsync(
            m => m.ProductCode == materialWarehouse.ProductCode && m.EntityId != request.MaterialWarehouseId, cancellationToken);

        if (isDuplicateProductCode)
        {
            result.AddErrorMessage("ProductCode đã tồn tại trên một bản ghi khác.");
            return result;
        }

        _ = Mapper.Map(request, existMaterialEntity);

        _ = materialWarehouseRepository.Update(existMaterialEntity);
        _ = await materialWarehouseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        result.Result = true;
        return result;
    }

}
