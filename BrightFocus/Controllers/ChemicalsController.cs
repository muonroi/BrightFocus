namespace BrightFocus.Controllers;
[Route("chemicals")]
[ApiVersion("1")]
public class ChemicalsController(IMediator mediator, Serilog.ILogger logger, IMapper mapper, IUnitOfWork unitOfWork) : MControllerBase(mediator, logger)
{
}
