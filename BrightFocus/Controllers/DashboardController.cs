namespace BrightFocus.Controllers;

[AllowAnonymous]
public class DashboardController(
    IMediator mediator,
    IMapper mapper,
    Serilog.ILogger logger) : MControllerBase(mediator, logger, mapper)
{
    [HttpPost("task", Name = nameof(CreateTask))]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpGet("task")]
    public async Task<IActionResult> GetTaskById([FromQuery] GetTaskDetailCommand command, CancellationToken cancellationToken)
    {
        MResponse<TaskListDto> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpGet("task/paging")]
    public async Task<IActionResult> GetTaskListPaging([FromQuery] GetTaskListCommand command, CancellationToken cancellationToken)
    {
        MResponse<MPagedResult<TaskListDto>> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();

    }

    [HttpPut("task")]
    public async Task<IActionResult> UpdateTask([FromBody] CreateOrUpdateTaskRequest request, CancellationToken cancellationToken)
    {
        UpdateTaskCommand command = new()
        {
            EntityId = request.EntityId,
            TaskName = request.TaskName,
            ProductName = request.ProductName,
            Material = request.Material,
            Size = request.Size,
            Weight = request.Weight,
            Color = request.Color,
            Employee = request.Employee,
            FactoryName = request.FactoryName,
            Warehouse = request.Warehouse,
            DeadlineDate = request.DeadlineDate,
            Note = request.Note,
            TaskDetails = request.TaskDetails,
            FileUrl = request.FileUrl
        };
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpDelete("task")]
    public async Task<IActionResult> DeleteTask([FromQuery] DeleteTaskCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpDelete("task-detail")]
    public async Task<IActionResult> DeleteTaskDetail([FromQuery] DeleteTaskDetailCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }
}
