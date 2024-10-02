namespace BrightFocus.Core.Domain.Inventory
{
    [Table("FinishProduct")]
    public class FinishProduct : MEntity
    {
        [Required]
        [MaxLength(50)]
        public string ClothId { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string ClothType { get; set; } = string.Empty;

        [Required]
        public int Weight { get; set; }

        [Required]
        public string Spindle { get; set; } = string.Empty;

        [Required]
        public int Size { get; set; }

        [Required]
        public int NumberOfCloth { get; set; }

        [Required]
        public int MeterOfCloth { get; set; }

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
