namespace BrightFocus.Controllers;

[ApiVersion("1.0")]
[ApiVersion(0.9, Deprecated = true)]
public class AuthController(IMediator mediator, Serilog.ILogger logger) : MControllerBase(mediator, logger)
{
}
