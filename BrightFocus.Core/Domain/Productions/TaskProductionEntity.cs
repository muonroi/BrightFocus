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
    public string EmployeeName { get; set; } = string.Empty;

    [MaxLength(255)]
    [Column(TypeName = "nvarchar")]
    public string FactoryName { get; set; } = string.Empty;

    public DateTime DeadlineDate { get; set; }

}
