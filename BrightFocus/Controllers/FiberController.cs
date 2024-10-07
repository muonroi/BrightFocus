namespace BrightFocus.Controllers;
public class FiberController(IMediator mediator, Serilog.ILogger logger, IMapper mapper, IUnitOfWork unitOfWork) : MControllerBase(mediator, logger)
{
}
