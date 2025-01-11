

namespace BrightFocus.Controllers
{
    [AllowAnonymous]
    public class CustomerController(
    IMediator mediator,
    IMapper mapper,
    Serilog.ILogger logger) : MControllerBase(mediator, logger, mapper)
    {
        [HttpGet("list-customer", Name = nameof(GetCustomerList))]
        public async Task<IActionResult> GetCustomerList([FromQuery] GetCustomerListCommand command, CancellationToken cancellationToken)
        {
            MResponse<IEnumerable<CustomerModel>> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }
    }
}
