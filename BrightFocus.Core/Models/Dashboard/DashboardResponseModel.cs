namespace BrightFocus.Core.Models.Dashboard
{
    public class DashboardResponseModel
    {
        public Guid? EntityId { get; set; }

        public string TaskName { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public string Material { get; set; } = string.Empty;

        public string Volume { get; set; } = string.Empty;

        public DateTime DeadlineDate { get; set; }

        public string Employee { get; set; } = string.Empty;

        public string Factory { get; set; } = string.Empty;
        public Guid TaskId { get; set; }
    }
}
