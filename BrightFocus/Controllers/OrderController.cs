

namespace BrightFocus.Controllers
{
    [AllowAnonymous]
    public class OrderController(
    IMediator mediator,
    IMapper mapper,
    Serilog.ILogger logger) : MControllerBase(mediator, logger, mapper)
    {
        [HttpGet("code", Name = nameof(GetOrderByCode))]
        public async Task<IActionResult> GetOrderByCode([FromQuery] GetOrderByCodeCommand command, CancellationToken cancellationToken)
        {
            MResponse<IEnumerable<TaskMaterialResponse>> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }
    }
}
