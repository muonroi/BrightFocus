



namespace BrightFocus.Controllers
{
    [AllowAnonymous]
    public class WarehouseController(
    IMediator mediator,
    IMapper mapper,
    Serilog.ILogger logger) : MControllerBase(mediator, logger, mapper)
    {
        [HttpGet("list-warehouse", Name = nameof(GetWarehouse))]
        public async Task<IActionResult> GetWarehouse([FromQuery] GetWarehouseCommand command, CancellationToken cancellationToken)
        {
            MResponse<MPagedResult<TaskMaterialResponse>> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }

        [HttpPut("update-warehouse", Name = nameof(UpdateWarehouse))]
        public async Task<IActionResult> UpdateWarehouse([FromBody] UpdateWarehouseCommand command, CancellationToken cancellationToken)
        {
            MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }
    }
}
