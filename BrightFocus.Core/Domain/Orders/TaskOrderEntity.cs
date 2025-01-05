namespace BrightFocus.Core.Domain.Orders
{
    [Table("TaskOrders")]
    public class TaskOrderEntity : MEntity
    {
        [MaxLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string TaskName { get; set; } = string.Empty;

        [MaxLength(100)]
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string CustomerCode { get; set; } = string.Empty;

        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CustomerName { get; set; } = string.Empty;

        [MaxLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string ProductName { get; set; } = string.Empty;

        public DateTime DeadlineDate { get; set; }

        public Guid EmployeeId { get; set; }

        [MaxLength(255)]
        public string FileUrl { get; set; } = string.Empty;

        public TaskType TaskType { get; set; }
    }
}
