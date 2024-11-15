

namespace BrightFocus.Application.Command.TaskCommand.UpdateTask;

public class UpdateTaskCommand : CreateTaskCommand, IRequest<MResponse<bool>>
{
    public Guid TaskId { get; set; }

}
