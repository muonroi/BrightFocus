namespace BrightFocus.Application.Command.DashboardCommand
{
    public class DeleteTaskCommand : IRequest<MResponse<bool>>
    {
        public Guid EntityId { get; set; }
    }
}
