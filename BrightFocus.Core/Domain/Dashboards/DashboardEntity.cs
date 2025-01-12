namespace BrightFocus.Core.Domain.Dashboards
{
    [Table("Dashboard")]
    [Index(nameof(TaskName))]

    public class DashboardEntity : MEntity
    {
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string TaskName { get; set; } = string.Empty;

        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]

        public string ProductName { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]

        public string Characteristic { get; set; } = string.Empty;

        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]

        public string Volume { get; set; } = string.Empty;

        public required DateTime DeadlineDate { get; set; }

        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]

        public string Employee { get; set; } = string.Empty;

        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]

        public string Factory { get; set; } = string.Empty;

        public Guid TaskId { get; set; }
    }
}
