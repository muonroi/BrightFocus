namespace BrightFocus.Controllers;
public class WasteProductController(IMediator mediator, Serilog.ILogger logger, IMapper mapper, IUnitOfWork unitOfWork) : MControllerBase(mediator, logger)
{
}
