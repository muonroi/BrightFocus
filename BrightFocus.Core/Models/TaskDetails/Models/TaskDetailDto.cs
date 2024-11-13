

namespace BrightFocus.Core.Models.TaskDetails.Models;

public class TaskDetailDto : IMapFrom<TaskDetail>
{
    public Guid? EntityId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
    public string Quantification { get; set; } = string.Empty;
    public string Width { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Characteristic { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
    public string Factory { get; set; } = string.Empty;
    public string Warehouse { get; set; } = string.Empty;
    public string ReceiptNumber { get; set; } = string.Empty;

    public DateTime? EntryDate { get; set; }
    public string Employee { get; set; } = string.Empty;

    public DateTime DeadlineDate { get; set; }
    public string FileNumber { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;

    public Guid TaskId { get; set; }
}
