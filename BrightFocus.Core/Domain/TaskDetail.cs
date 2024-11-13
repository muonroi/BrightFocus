namespace BrightFocus.Core.Domain;

[Table("TaskDetails")]
[Index(nameof(ProductName))]
public class TaskDetail : MEntity
{
    [MaxLength(255)]
    [Required]
    [Column(TypeName = "nvarchar")]
    public string ProductName { get; set; } = string.Empty;
    [MaxLength(255)]
    [Required]
    public string Material { get; set; } = string.Empty;
    [MaxLength(255)]
    [Required]
    public string Quantification { get; set; } = string.Empty;
    [MaxLength(255)]
    [Required]
    public string Width { get; set; } = string.Empty;
    [MaxLength(255)]
    [Required]
    public string Color { get; set; } = string.Empty;
    [MaxLength(255)]
    [Required]
    public string Characteristic { get; set; } = string.Empty;
    [MaxLength(255)]
    [Required]
    public string Quantity { get; set; } = string.Empty;
    [MaxLength(255)]
    [Required]
    public string Factory { get; set; } = string.Empty;
    [MaxLength(255)]
    [Required]
    public string Warehouse { get; set; } = string.Empty;
    [MaxLength(255)]
    [Required]
    public string ReceiptNumber { get; set; } = string.Empty;

    public DateTime? EntryDate { get; set; }
    [MaxLength(255)]
    [Required]
    public string Employee { get; set; } = string.Empty;

    public DateTime DeadlineDate { get; set; }
    [MaxLength(500)]
    [Required]
    public string FileNumber { get; set; } = string.Empty;
    [MaxLength(500)]
    [Required]
    public string Notes { get; set; } = string.Empty;

    [Required]
    public Guid TaskId { get; set; }
}
