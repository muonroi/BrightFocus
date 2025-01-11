namespace BrightFocus.Core.Domain.Productions
{
    [Table("ProductProcess")]
    public class ProductProcessEntity : MEntity
    {
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ProductOne { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ProductTwo { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ProductThree { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ProductFour { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ProductFive { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ProductSix { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ProductSeven { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ProductEight { get; set; } = string.Empty;

        [Required]
        public Guid TaskId { get; set; }

        public int WrapperId { get; set; }

    }
}
