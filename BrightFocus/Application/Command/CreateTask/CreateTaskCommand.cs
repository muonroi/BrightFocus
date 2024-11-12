namespace BrightFocus.Application.Command.CreateTask;

public class CreateTaskCommand : CreateOrUpdateTaskRequest, IMapFrom<TaskList>, IRequest<MResponse<bool>>
{
}
