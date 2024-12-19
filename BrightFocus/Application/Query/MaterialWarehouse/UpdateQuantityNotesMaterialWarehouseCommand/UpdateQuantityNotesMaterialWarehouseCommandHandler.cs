
namespace BrightFocus.Application.Query.MaterialWarehouse.UpdateQuantityNotesMaterialWarehouseCommand
{
    public class UpdateQuantityNotesMaterialWarehouseCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<UpdateQuantityNotesMaterialWarehouseCommand, MResponse<bool>>

    {
        public Task<MResponse<bool>> Handle(UpdateQuantityNotesMaterialWarehouseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
