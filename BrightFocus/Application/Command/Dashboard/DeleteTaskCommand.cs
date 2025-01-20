namespace BrightFocus.Application.Command.Dashboard
{
    public class DeleteTaskCommand : IRequest<MResponse<bool>>
    {
        public Guid EntityId { get; set; }
    }
}
