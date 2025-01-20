namespace BrightFocus.Application.Command.Task.ProductionTask
{
    public class ProductionTaskCommand : IRequest<MResponse<bool>>
    {
        public Guid? EntityId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string Employee { get; set; } = string.Empty;
        public string Factory { get; set; } = string.Empty;
        public DateTime DeadlineDate { get; set; }
        public List<CreateOrUpdateTaskRequest> ProductWrappers { get; set; } = [];
    }
}
