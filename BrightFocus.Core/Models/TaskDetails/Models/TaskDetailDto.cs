

namespace BrightFocus.Core.Models.TaskDetails.Models;

public class TaskDetailDto : IMapFrom<TaskDetail>
{
    public Guid? EntityId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string Material { get; set; } = string.Empty;

    public double Size { get; set; }

    public double Weight { get; set; }

    public string Color { get; set; } = string.Empty;

    public double FabrictMeter { get; set; }

    public string Employee { get; set; } = string.Empty;

    public string Warehouse { get; set; } = string.Empty;

    public DateTime DeadlineDate { get; set; }

    public string Note { get; set; } = string.Empty;
}
