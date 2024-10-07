namespace BrightFocus.Controllers;
public class PaperTubeController(IMediator mediator, Serilog.ILogger logger, IMapper mapper, IUnitOfWork unitOfWork) : MControllerBase(mediator, logger)
{
}
