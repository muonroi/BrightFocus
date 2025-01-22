namespace BrightFocus.Controllers;

[AllowAnonymous]
public class DashboardController(
    IMediator mediator,
    IMapper mapper,
    Serilog.ILogger logger) : MControllerBase(mediator, logger, mapper)
{

    [HttpDelete("task", Name = nameof(DeleteTask))]
    public async Task<IActionResult> DeleteTask([FromQuery] DeleteTaskCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }
    [HttpGet("task-detail", Name = nameof(GetTaskDetail))]
    public async Task<IActionResult> GetTaskDetail([FromQuery] GetTaskDetailCommand command, CancellationToken cancellationToken)
    {
        MResponse<TaskResponse> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }
    [HttpGet("task", Name = nameof(GetDashboardTask))]
    public async Task<IActionResult> GetDashboardTask([FromQuery] GetDashboardTaskCommand command, CancellationToken cancellationToken)
    {
        MResponse<MPagedResult<DashboardResponseModel>> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpPost("task-production", Name = nameof(CreateProductionTask))]
    public async Task<IActionResult> CreateProductionTask([FromBody] ProductionTaskCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpPost("task-import-export", Name = nameof(CreateProductionImportExportTask))]
    public async Task<IActionResult> CreateProductionImportExportTask([FromBody] ImportExportTaskCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpPost("task-order", Name = nameof(CreateOrderTask))]
    public async Task<IActionResult> CreateOrderTask([FromBody] OrderTaskCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpPost("task-customer", Name = nameof(CreateCustomerTask))]
    public async Task<IActionResult> CreateCustomerTask([FromBody] CustomerTaskCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }
}
