namespace BrightFocus.Application.Command.TaskCommand.DeleteTaskDetail
{
    public class DeleteTaskDetailCommand : IRequest<MResponse<bool>>
    {
        public IEnumerable<Guid> TaskDetailIds { get; set; } = [];
    }
}
