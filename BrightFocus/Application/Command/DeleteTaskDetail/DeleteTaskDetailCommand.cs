namespace BrightFocus.Application.Command.DeleteTaskDetail
{
    public class DeleteTaskDetailCommand : IRequest<MResponse<bool>>
    {
        public IEnumerable<Guid> TaskDetailIds { get; set; } = [];
    }
}
