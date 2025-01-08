







namespace BrightFocus.Controllers;

[AllowAnonymous]
public class DashboardController(
    IMediator mediator,
    IMapper mapper,
    Serilog.ILogger logger) : MControllerBase(mediator, logger, mapper)
{
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
}
