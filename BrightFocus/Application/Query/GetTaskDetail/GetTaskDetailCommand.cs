

namespace BrightFocus.Application.Query.GetTaskDetail
{
    public class GetTaskDetailCommand : IRequest<MResponse<ProductionTaskResponse>>
    {
        public Guid EntityId { get; set; }
    }
}
