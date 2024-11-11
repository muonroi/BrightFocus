namespace BrightFocus.Application.Query.Task.GetTaskDetail
{
    public class GetTaskDetailCommand : IRequest<MResponse<TaskDetailDto>>
    {
        public Guid TaskId { get; set; }
    }
}
