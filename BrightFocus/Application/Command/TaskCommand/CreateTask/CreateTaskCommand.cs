namespace BrightFocus.Application.Command.TaskCommand.CreateTask;

public class CreateTaskCommand : CreateOrUpdateTaskRequest, IMapFrom<TaskListEntity>, IRequest<MResponse<bool>>
{
}
