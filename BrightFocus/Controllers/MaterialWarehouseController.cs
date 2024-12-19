



namespace BrightFocus.Controllers
{
    [AllowAnonymous]
    public class MaterialWarehouseController(
        IMediator mediator,
        Serilog.ILogger logger,
        IMapper mapper) : MControllerBase(mediator, logger, mapper)
    {
        [HttpPost(Name = nameof(CreateMaterialWarehouse))]
        public async Task<IActionResult> CreateMaterialWarehouse([FromBody] CreateMaterialWarehouseCommand command, CancellationToken cancellationToken)
        {
            MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }
        [HttpPost("material-warehouse/import", Name = nameof(ImportMaterialWarehouse))]
        public async Task<IActionResult> ImportMaterialWarehouse([FromForm] ImportMaterialWarehouseCommand command, CancellationToken cancellationToken)
        {
            MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }
        [HttpGet()]
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
        [HttpPut]
        public async Task<IActionResult> UpdateMaterialWarehouse([FromQuery] Guid materialWarehouseId, [FromBody] CreateOrUpdateMaterialWarehousesRequest request, CancellationToken cancellationToken)
        {
            UpdateMaterialWarehouseCommand command = Mapper.Map<UpdateMaterialWarehouseCommand>(request);
            command.MaterialWarehouseId = materialWarehouseId;
            MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }
        [HttpPut("quantity-notes")]
        public async Task<IActionResult> UpdateQuantityNotesMaterialWarehouse([FromBody] UpdateQuantityNotesMaterialWarehouseRequest request, CancellationToken cancellationToken)
        {
            UpdateMaterialWarehouseCommand command = Mapper.Map<UpdateMaterialWarehouseCommand>(request);
            MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMaterialWarehouse([FromQuery] DeleteMaterialWarehouseCommand command, CancellationToken cancellationToken)
        {
            MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }
    }
}
