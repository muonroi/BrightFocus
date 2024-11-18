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
    public async Task<IActionResult> UpdateTask([FromQuery] Guid taskId, [FromBody] CreateOrUpdateTaskRequest request, CancellationToken cancellationToken)
    {
        UpdateTaskCommand command = Mapper.Map<UpdateTaskCommand>(request);
        command.TaskId = taskId;
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
