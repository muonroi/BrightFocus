namespace BrightFocus.Core.Domain.Inventory
{
    [Table("Chemicals")]
    public class Chemicals : MEntity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Uses { get; set; } = string.Empty;
        public int Volume { get; set; }
        public int Weight { get; set; }
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
