namespace BrightFocus.Core.Models.TaskLists.Response
{
    public class ProductionTaskResponse
    {
        public Guid? EntityId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string Employee { get; set; } = string.Empty;
        public string Factory { get; set; } = string.Empty;
        public required string DeadlineDate { get; set; }
        public CreateOrUpdateTaskResponse ProductWrappers { get; set; } = new();
    }
}
