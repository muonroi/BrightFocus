namespace BrightFocus.Core.Domain.Customers
{
    [Table("Customers")]
    [Index(nameof(CustomerCode))]
    public class CustomerEntity : MEntity
    {
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
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
        public string Address { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(500)]
        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string Note { get; set; } = string.Empty;
    }
}
