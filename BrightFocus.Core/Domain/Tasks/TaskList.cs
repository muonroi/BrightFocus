﻿

namespace BrightFocus.Core.Domain.Tasks
{
    [Table("TaskList")]
    [Index(nameof(TaskName), additionalPropertyNames: nameof(ProductName))]
    public class TaskList : MEntity
    {
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar")]
        public string TaskName { get; set; } = string.Empty;

        [MaxLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string ProductName { get; set; } = string.Empty;

        public int Quatity { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string Description { get; set; } = string.Empty;

        public DateTime DeadlineDate { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string Note { get; set; } = string.Empty;

        public TaskType TaskType { get; set; }

    }
}