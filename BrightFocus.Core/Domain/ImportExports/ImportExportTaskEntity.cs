namespace BrightFocus.Core.Domain.ImportExports
{
    [Table("ImportExportTask")]
    [Index(nameof(TaskName))]
    public class ImportExportTaskEntity : MEntity
    {
        [MaxLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string TaskName { get; set; } = string.Empty;

        [MaxLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Material { get; set; } = string.Empty;

        [MaxLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Source { get; set; } = string.Empty;

        [MaxLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string EmployeeName { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column(TypeName = "nvarchar")]
        public string FactoryName { get; set; } = string.Empty;

        public DateTime DeadlineDate { get; set; }
    }
}
