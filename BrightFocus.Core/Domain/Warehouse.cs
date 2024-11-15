namespace BrightFocus.Core.Domain;

[Table("Warehouses")]
[Index(nameof(Name), nameof(ReceiptNumber), nameof(RecordNumber))]  // Index on searchable fields
public class WarehouseEntity : MEntity
{
    /// <summary>
    /// Name of the item or material in the warehouse (supports Vietnamese characters)
    /// </summary>
    [MaxLength(255)]
    [Required]
    [Column(TypeName = "nvarchar(255)")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Category of the item or material (e.g., chemical, paper)
    /// </summary>
    [MaxLength(100)]
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Description or additional details about the item
    /// </summary>
    [MaxLength(500)]
    [Column(TypeName = "nvarchar(500)")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Weight of the item
    /// </summary>
    [Required]
    public double Weight { get; set; }

    /// <summary>
    /// Unit of weight (e.g., kg, lbs)
    /// </summary>
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string UnitWeight { get; set; } = string.Empty;

    /// <summary>
    /// Factory where the item is produced or sourced from
    /// </summary>
    [MaxLength(255)]
    [Column(TypeName = "varchar(255)")]
    public string Factory { get; set; } = string.Empty;

    /// <summary>
    /// Warehouse location of the item
    /// </summary>
    [MaxLength(255)]
    [Column(TypeName = "varchar(255)")]
    public string Warehouse { get; set; } = string.Empty;

    /// <summary>
    /// Receipt number associated with the item
    /// </summary>
    [MaxLength(100)]
    [Column(TypeName = "varchar(100)")]
    public string ReceiptNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date when the item was entered into the warehouse
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? EntryDate { get; set; }

    /// <summary>
    /// Record number for tracking the item
    /// </summary>
    [MaxLength(100)]
    [Column(TypeName = "varchar(100)")]
    public string RecordNumber { get; set; } = string.Empty;
}
