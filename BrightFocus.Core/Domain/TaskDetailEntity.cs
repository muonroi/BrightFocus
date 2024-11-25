namespace BrightFocus.Core.Domain;

[Table("TaskDetails")]
[Index(nameof(ProductName))]
public class TaskDetailEntity : MEntity
{
    /// <summary>
    /// Name of the product (supports Vietnamese characters, max 255 characters)
    /// </summary>
    [MaxLength(255)]
    [Column(TypeName = "nvarchar(255)")]
    public string? ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Type of material, stored as non-Unicode (varchar)
    /// </summary>
    [MaxLength(100)]
    [Column(TypeName = "varchar(100)")]
    public string? Material { get; set; } = string.Empty;

    /// <summary>
    /// Quantification value as integer (e.g., quantity in numeric terms)
    /// </summary>
    public double? Quantification { get; set; }


    /// <summary>
    /// Width of the material in integer units (e.g., cm or mm)
    /// </summary>
    public double? Width { get; set; }

    /// <summary>
    /// Color of the material, stored as varchar
    /// </summary>
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string? Color { get; set; } = string.Empty;

    /// <summary>
    /// Distinct characteristic of the material, stored as varchar
    /// </summary>
    [MaxLength(100)]
    [Column(TypeName = "varchar(100)")]
    public string? Characteristic { get; set; } = string.Empty;

    /// <summary>
    /// Quantity of material available as integer
    /// </summary>
    [Required]
    public double Quantity { get; set; }

    /// <summary>
    /// Factory where the item is produced or stored, stored as varchar
    /// </summary>
    [MaxLength(255)]
    [Column(TypeName = "varchar(255)")]
    public string? Factory { get; set; } = string.Empty;

    /// <summary>
    /// Warehouse location of the item, stored as varchar
    /// </summary>
    [MaxLength(255)]
    [Column(TypeName = "varchar(255)")]
    public string Warehouse { get; set; } = string.Empty;

    /// <summary>
    /// Receipt number for inventory entry, stored as varchar
    /// </summary>
    [MaxLength(100)]
    [Column(TypeName = "varchar(100)")]
    public string? ReceiptNumber { get; set; } = string.Empty;

    /// <summary>
    /// File or record number for documentation and tracking, stored as varchar
    /// </summary>
    [MaxLength(100)]
    [Column(TypeName = "varchar(100)")]
    public string? FileNumber { get; set; } = string.Empty;

    /// <summary>
    /// Name of the employee responsible, stored as varchar
    /// </summary>
    [MaxLength(150)]
    [Column(TypeName = "varchar(150)")]
    public string Employee { get; set; } = string.Empty;

    /// <summary>
    /// Source of product
    /// </summary>
    [MaxLength(150)]
    [Column(TypeName = "varchar(150)")]
    public string Source { get; set; } = string.Empty;

    /// <summary>
    /// Deadline or expiration date of the material (if applicable)
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime DeadlineDate { get; set; }

    /// <summary>
    /// Additional notes or comments, stored as varchar
    /// </summary>
    [MaxLength(500)]
    [Column(TypeName = "nvarchar(500)")]
    public string? Note { get; set; } = string.Empty;

    [Required]
    public Guid TaskId { get; set; }
}
