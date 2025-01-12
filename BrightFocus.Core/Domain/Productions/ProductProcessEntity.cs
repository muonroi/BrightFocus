namespace BrightFocus.Core.Domain.Productions
{
    [Table("ProductProcess")]
    public class ProductProcessEntity : MEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string StepOne { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string StepTwo { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string StepThree { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string StepFour { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string StepFive { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string StepSix { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string StepSeven { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string StepEight { get; set; } = string.Empty;

        [Required]
        public Guid TaskId { get; set; }

        public int WrapperId { get; set; }

    }
}
