namespace BrightFocus.Application.Command.DeleteTask
{
    public class DeleteTaskCommand : IRequest<MResponse<bool>>
    {
        public Guid[] TaskIds { get; set; } = [];
    }
}
