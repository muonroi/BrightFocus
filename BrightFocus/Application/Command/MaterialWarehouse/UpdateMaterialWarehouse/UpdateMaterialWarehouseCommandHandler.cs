





namespace BrightFocus.Application.Command.MaterialWarehouse.UpdateMaterialWarehouse;

public class UpdateMaterialWarehouseCommandHandler(IMapper mapper, MAuthenticateInfoContext tokenInfo, IAuthenticateRepository authenticateRepository, Serilog.ILogger logger, IMediator mediator, MPaginationConfig paginationConfig,
    IMaterialWarehouseRepository materialWarehouseRepository) :
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

        MaterialWarehouseEntity? existMaterialEntity = await materialWarehouseRepository.GetByGuidAsync(request.TaskId);
        if (existMaterialEntity is null)
        {
            result.StatusCode = StatusCodes.Status404NotFound;
            result.AddErrorMessage(nameof(AllTaskError.NotFound));
            return result;
        }

        _ = Mapper.Map(request, existMaterialEntity);

        _ = materialWarehouseRepository.Update(existMaterialEntity);

        await materialWarehouseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        result.Result = true;

        return result;

    }
}
