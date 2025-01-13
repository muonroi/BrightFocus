

namespace BrightFocus.Application.Query.GetTaskDetail
{
    public class GetTaskDetailCommand : IRequest<MResponse<TaskResponse>>
    {
        public Guid EntityId { get; set; }

        public int TaskType { get; set; }
    }
}
