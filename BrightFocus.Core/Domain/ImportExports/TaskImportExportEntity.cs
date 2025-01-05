namespace BrightFocus.Core.Domain.ImportExports
{
    [Table("TaskImportExport")]
    [Index(nameof(TaskName))]
    public class TaskImportExportEntity : MEntity
    {
        [MaxLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string TaskName { get; set; } = string.Empty;

        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Material { get; set; } = string.Empty;

        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Source { get; set; } = string.Empty;

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
}
