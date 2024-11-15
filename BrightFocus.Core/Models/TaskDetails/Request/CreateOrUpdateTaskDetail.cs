namespace BrightFocus.Core.Models.TaskDetails.Request
{
    public class CreateOrUpdateTaskDetail : IMapFrom<TaskDetailEntity>
    {
        public string ProductName { get; set; } = string.Empty;

        public string Material { get; set; } = string.Empty;

        public double Size { get; set; }

        public double Weight { get; set; }

        public string Color { get; set; } = string.Empty;

        public string Employee { get; set; } = string.Empty;

        public string FactoryName { get; set; } = string.Empty;

        public string Warehouse { get; set; } = string.Empty;

        public DateTime DeadlineDate { get; set; }

        public string Note { get; set; } = string.Empty;

        public string File { get; set; } = string.Empty;
    }
}
