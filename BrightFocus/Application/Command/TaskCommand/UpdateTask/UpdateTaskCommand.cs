

namespace BrightFocus.Application.Command.TaskCommand.UpdateTask;

public class UpdateTaskCommand : CreateOrUpdateTaskRequest, IMapFrom<TaskListEntity>, IRequest<MResponse<bool>>
{
}
