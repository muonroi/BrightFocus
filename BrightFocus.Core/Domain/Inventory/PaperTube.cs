namespace BrightFocus.Core.Domain.Inventory
{
    [Table("PaperTube")]
    public class PaperTube : MEntity
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public double Vat { get; set; }
        public decimal UnitPriceVat { get; set; }

        [Required]
        [MaxLength(100)]
        public string ManufacturingPlant { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string FactoryImport { get; set; } = string.Empty;

        public double ExportDateTs { get; set; }

        public double ImportDateTs { get; set; }

        [Required]
        [MaxLength(255)]
        public string ReceiptImport { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string ReceiptExport { get; set; } = string.Empty;


        [Required]
        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string Note { get; set; } = string.Empty;
    }
}
