

namespace BrightFocus.Controllers
{
    [AllowAnonymous]
    public class MaterialWarehouseController(
        IMediator mediator,
        Serilog.ILogger logger,
        IMapper mapper) : MControllerBase(mediator, logger, mapper)
    {
        [HttpPost("material-warehouse", Name = nameof(CreateMaterialWarehouse))]
        public async Task<IActionResult> CreateMaterialWarehouse([FromBody] CreateMaterialWarehouseCommand command, CancellationToken cancellationToken)
        {
            MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }
        [HttpGet("material-warehouse")]
        public async Task<IActionResult> GetMaterialWarehouseById([FromQuery] GetMaterialWarehouseDetailCommand command, CancellationToken cancellationToken)
        {
            MResponse<MaterialWarehousesDto> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }
        [HttpGet("material-warehouse/paging")]
        public async Task<IActionResult> GetMaterialWarehouseListPaging([FromQuery] GetMaterialWarehouseListCommand command, CancellationToken cancellationToken)
        {
            MResponse<MPagedResult<MaterialWarehousesDto>> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }
        [HttpPut("material-warehouse")]
        public async Task<IActionResult> UpdateMaterialWarehouse([FromQuery] Guid materialWarehouseId, [FromBody] CreateOrUpdateMaterialWarehousesRequest request, CancellationToken cancellationToken)
        {
            UpdateMaterialWarehouseCommand command = Mapper.Map<UpdateMaterialWarehouseCommand>(request);
            command.MaterialWarehouseId = materialWarehouseId;
            MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }
        [HttpDelete("material-warehouse")]
        public async Task<IActionResult> DeleteMaterialWarehouse([FromQuery] DeleteMaterialWarehouseCommand command, CancellationToken cancellationToken)
        {
            MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }
    }
}
