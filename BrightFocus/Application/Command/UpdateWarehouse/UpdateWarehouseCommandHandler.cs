
namespace BrightFocus.Application.Command.UpdateWarehouse
{
    public class UpdateWarehouseCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        IImportRepository importRepository
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<UpdateWarehouseCommand, MResponse<bool>>
    {
        public async Task<MResponse<bool>> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
        {
            MResponse<bool> result = new();
            if (request.Data == null || !request.Data.Any())
            {
                result.AddErrorMessage("No data provided for update.");
                return result;
            }

            _ = await importRepository.UpdateWarehouseVolumesAsync(request.Data, cancellationToken);
            result.Result = true;
            return result;
        }
    }
}
