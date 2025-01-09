namespace BrightFocus.Core.Domain.Orders
{
    [Table("TaskOrders")]
    [Index(nameof(TaskName), Name = "IX_TaskOrders_TaskName")]
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

        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string EmployeeName { get; set; } = string.Empty;

        public DateTime DeadlineDate { get; set; }


    }
}
