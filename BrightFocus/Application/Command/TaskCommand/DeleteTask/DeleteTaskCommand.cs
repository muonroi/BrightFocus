namespace BrightFocus.Application.Command.TaskCommand.DeleteTask;

public class DeleteTaskCommand : IRequest<MResponse<bool>>
{
    public List<Guid> TaskIds { get; set; } = [];
}
