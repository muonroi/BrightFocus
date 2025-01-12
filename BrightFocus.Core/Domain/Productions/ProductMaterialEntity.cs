namespace BrightFocus.Core.Domain.Productions
{
    [Table("ProductMaterials")]
    [Index(nameof(ProductName))]
    public class ProductMaterialEntity : MEntity
    {
        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        [MaxLength(255)]
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Cấu trúc
        /// </summary>
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Ingredient { get; set; } = string.Empty;


        /// <summary>
        /// Đặc điểm sản phẩm
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Characteristic { get; set; } = string.Empty;

        /// <summary>
        /// Mã màu
        /// </summary>
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string ColorCode { get; set; } = string.Empty;

        /// <summary>
        /// Mã LOT
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string FileNumber { get; set; } = string.Empty;

        /// <summary>
        /// Khối lượng sản phẩm
        /// </summary>
        [Required]
        public double Volume { get; set; }

        /// <summary>
        /// Vị trí kho lưu trữ
        /// </summary>
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string Warehouse { get; set; } = string.Empty;

        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string OrderNumber { get; set; } = string.Empty;


        /// <summary>
        /// Ghi chú thêm
        /// </summary>
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string Note { get; set; } = string.Empty;


        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Structure { get; set; } = string.Empty;

        [Required]
        public Guid TaskId { get; set; }

        public int WrapperId { get; set; }

    }
}
