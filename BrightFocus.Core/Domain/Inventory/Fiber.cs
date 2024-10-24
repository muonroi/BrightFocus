namespace BrightFocus.Core.Domain.Inventory
{
    [Table("Fiber")]
    public class Fiber : MEntity
    {
        [Required]
        [MaxLength(50)]
        public string ProductId { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Index { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string ColorCode { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int Volume { get; set; }
        public int TotalVolume { get; set; }
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar")]
        public string FactoryName { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string Note { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string ReceiptImport { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string ReceiptExport { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar")]
        public string FactoryImport { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar")]
        public string FactoryExport { get; set; } = string.Empty;
    }
}
