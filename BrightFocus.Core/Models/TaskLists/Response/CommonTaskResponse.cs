namespace BrightFocus.Core.Models.TaskLists.Response
{
    public class CommonTaskResponse
    {
        public Guid? EntityId { get; set; }

        public string TaskName { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public string Material { get; set; } = string.Empty;

        public string Volume { get; set; } = string.Empty;

        public DateTime DeadlineDate { get; set; }

        public string Employee { get; set; } = string.Empty;

        public string Factory { get; set; } = string.Empty;
    }
}
