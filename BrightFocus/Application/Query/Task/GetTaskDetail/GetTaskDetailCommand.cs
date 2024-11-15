namespace BrightFocus.Application.Query.Task.GetTaskDetail;

public class GetTaskDetailCommand : IRequest<MResponse<TaskListDto>>
{
    public Guid TaskId { get; set; }
}
