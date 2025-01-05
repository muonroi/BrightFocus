namespace BrightFocus.Core.Domain.Productions;

[Table("TaskProduction")]
[Index(nameof(TaskName))]
public class TaskProductionEntity : MEntity
{
    [MaxLength(255)]
    [Required]
    [Column(TypeName = "nvarchar")]
    public string TaskName { get; set; } = string.Empty;

    [MaxLength(255)]
    [Required]
    [Column(TypeName = "nvarchar")]
    public string ProductName { get; set; } = string.Empty;

    [MaxLength(255)]
    [Column(TypeName = "nvarchar")]
    public string Ingredient { get; set; } = string.Empty;

    public DateTime DeadlineDate { get; set; }

    public Guid EmployeeId { get; set; }

    [MaxLength(255)]
    public string FileUrl { get; set; } = string.Empty;

    [MaxLength(255)]
    [Column(TypeName = "nvarchar")]
    public string FactoryName { get; set; } = string.Empty;

    public TaskType TaskType { get; set; }
}
