namespace BrightFocus.Core.Models.TaskDetails.Models;

public class TaskDetailDto : IMapFrom<TaskDetailEntity>
{
    public Guid? EntityId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string Material { get; set; } = string.Empty;

    public double Quantification { get; set; }

    public double Width { get; set; }

    public string? Color { get; set; } = string.Empty;

    public string? Characteristic { get; set; } = string.Empty;

    public double Quantity { get; set; }

    public string Warehouse { get; set; } = string.Empty;

    public string? FileNumber { get; set; } = string.Empty;

    public string Employee { get; set; } = string.Empty;

    public DateTime DeadlineDate { get; set; }

    public string? Note { get; set; } = string.Empty;

    public Guid TaskId { get; set; }
}
