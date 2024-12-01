

namespace BrightFocus.Application.Command.MaterialWarehouse.CreateMaterialWarehouse;

public class CreateMaterialWarehouseCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    IMaterialWarehouseRepository materialWarehouseRepository,
    IMaterialWarehouseQuery materialWarehouseQuery
    )
        : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<CreateMaterialWarehouseCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(CreateMaterialWarehouseCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();

        // validate request
        MaterialWarehouseEntity materialWarehouse = Mapper.Map<CreateMaterialWarehouseCommand, MaterialWarehouseEntity>(request);

        if (!materialWarehouse.IsValid())
        {
            result.StatusCode = StatusCodes.Status400BadRequest;
            result.AddResultFromErrorList(materialWarehouse.ErrorMessages);
            return result;
        }

        bool isDuplicateProductCode = await materialWarehouseQuery
            .ExistsAsync(m => m.ProductCode == materialWarehouse.ProductCode);

        if (isDuplicateProductCode)
        {
            result.StatusCode = StatusCodes.Status200OK;
            result.AddErrorMessage("ProductCode đã tồn tại.");
            return result;
        }
        _ = materialWarehouseRepository.Add(materialWarehouse);
        _ = await materialWarehouseRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        result.Result = true;
        return result;
    }
}
