

namespace BrightFocus.Core.Models.TaskDetails.Models;

public class TaskDetailDto : IMapFrom<TaskDetailEntity>
{
    public Guid? EntityId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string Material { get; set; } = string.Empty;

    public int Quantification { get; set; }


    public string UnitQuantification { get; set; } = string.Empty;

    public int Width { get; set; }

    public string UnitWidth { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public string Characteristic { get; set; } = string.Empty;


    public int Quantity { get; set; }


    public string UnitQuantity { get; set; } = string.Empty;


    public string Factory { get; set; } = string.Empty;

    public string Warehouse { get; set; } = string.Empty;


    public string ReceiptNumber { get; set; } = string.Empty;

    public DateTime? EntryDate { get; set; }

    public string FileNumber { get; set; } = string.Empty;

    public string Employee { get; set; } = string.Empty;

    public DateTime DeadlineDate { get; set; }

    public string Note { get; set; } = string.Empty;

    [Required]
    public Guid TaskId { get; set; }
}
