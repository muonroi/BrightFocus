

namespace BrightFocus.Core.Domain;

[Table("TaskList")]
[Index(nameof(ProductName))]
public class TaskList : MEntity
{
    [MaxLength(255)]
    [Required]
    [Column(TypeName = "nvarchar")]
    public string ProductName { get; set; } = string.Empty;

    [MaxLength(255)]
    [Required]
    [Column(TypeName = "nvarchar")]
    public string Material { get; set; } = string.Empty;

    [MaxLength(255)]
    [Required]
    public double Size { get; set; }

    [MaxLength(255)]
    [Required]
    public double Weight { get; set; }

    [MaxLength(255)]
    [Required]
    public string Color { get; set; } = string.Empty;

    [MaxLength(255)]
    [Required]
    [Column(TypeName = "nvarchar")]
    public string Employee { get; set; } = string.Empty;

    [MaxLength(255)]
    [Required]
    [Column(TypeName = "nvarchar")]
    public string FactoryName { get; set; } = string.Empty;

    [MaxLength(255)]
    [Required]
    [Column(TypeName = "nvarchar")]
    public string Warehouse { get; set; } = string.Empty;

    public DateTime DeadlineDate { get; set; }

    [MaxLength(500)]
    [Column(TypeName = "nvarchar")]
    public string Note { get; set; } = string.Empty;

    [MaxLength(255)]
    public string File { get; set; } = string.Empty;

    public TaskType TaskType { get; set; }

}
