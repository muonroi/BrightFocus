﻿namespace BrightFocus.Application.Command.MaterialWarehouse.CreateMaterialWarehouse;

public class CreateMaterialWarehouseCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    IMaterialWarehouseRepository materialWarehouseRepository
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
        materialWarehouseRepository.Add(materialWarehouse);
        await materialWarehouseRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        result.Result = true;
        return result;
    }
}