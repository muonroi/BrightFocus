namespace BrightFocus.Core.Domain;

[Table("TaskLists")]
[Index(nameof(TaskName))]
public class TaskListEntity : MEntity
{
    [MaxLength(255)]
    [Required]
    [Column(TypeName = "nvarchar")]
    public string TaskName { get; set; } = string.Empty;

    [MaxLength(255)]
    [Required]
    [Column(TypeName = "nvarchar")]
    public string Employee { get; set; } = string.Empty;

    [MaxLength(255)]
    [Column(TypeName = "nvarchar")]
    public string? Customer { get; set; } = string.Empty;

    public DateTime DeadlineDate { get; set; }

    [MaxLength(500)]
    [Column(TypeName = "nvarchar")]
    public string? Note { get; set; } = string.Empty;

    [MaxLength(255)]
    public string FileUrl { get; set; } = string.Empty;
    
    [MaxLength(255)]
    [Column(TypeName = "nvarchar")]
    
    public string Process { get; set; } = string.Empty;

    public TaskType TaskType { get; set; }
}
