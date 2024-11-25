namespace BrightFocus.Core.Domain
{
    [Table("DeliveryWarehouses")]
    public class DeliveryWarehouseEntity : MEntity
    {
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string FromWarehouse { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string ToWarehouse { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string ProductCode { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public double Quantity { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Employee { get; set; } = string.Empty;
        [Required]
        public DeliveryType DeliveryType { get; set; }

        [Required]
        public Guid TaskId { get; set; }
    }
}
