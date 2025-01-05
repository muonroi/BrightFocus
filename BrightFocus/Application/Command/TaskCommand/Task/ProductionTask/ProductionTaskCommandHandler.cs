
namespace BrightFocus.Application.Command.TaskCommand.Task.ProductionTask
{
    public class ProductionTaskCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<ProductionTaskCommand, MResponse<bool>>
    {
        public MResponse<bool> Handle(ProductionTaskCommand request, CancellationToken cancellationToken)
        {
            _ = new MResponse<bool>();

        }
    }
}
