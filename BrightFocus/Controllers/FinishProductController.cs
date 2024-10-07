namespace BrightFocus.Controllers;
public class FinishProductController(IMediator mediator, Serilog.ILogger logger, IMapper mapper, IUnitOfWork unitOfWork) : MControllerBase(mediator, logger)
{
}
