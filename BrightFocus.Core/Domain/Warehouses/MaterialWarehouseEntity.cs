﻿namespace BrightFocus.Core.Domain.Warehouses
{
    [Table("MaterialWarehouses")]
    [Index(nameof(ProductName), nameof(Characteristic), nameof(FileNumber))]
    public class MaterialWarehouseEntity : MEntity
    {
        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        [MaxLength(255)]
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string ProductCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        [MaxLength(255)]
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Loại nguyên liệu
        /// </summary>
        [MaxLength(100)]
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Material { get; set; } = string.Empty;

        /// <summary>
        /// Giá trị định lượng
        /// </summary>
        [Required]
        public double Quantification { get; set; }

        /// <summary>
        /// Màu sắc
        /// </summary>
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Color { get; set; } = string.Empty;

        /// <summary>
        /// Đặc điểm sản phẩm
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Characteristic { get; set; } = string.Empty;

        /// <summary>
        /// Số lượng sản phẩm
        /// </summary>
        [Required]
        public double Quantity { get; set; }

        /// <summary>
        /// Thể tích sản phẩm
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
        /// Số biên nhận
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string ReceiptNumber { get; set; } = string.Empty;

        /// <summary>
        /// Số hồ sơ lưu trữ
        /// </summary>
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string FileNumber { get; set; } = string.Empty;

        /// <summary>
        /// Loại sản phẩm nguyên liệu
        /// </summary>
        [Required]
        public MaterialProductType MaterialProductType { get; set; }

        /// <summary>
        /// Ghi chú thêm
        /// </summary>
        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// Giá sản phẩm
        /// </summary>
        [Required]
        public double Price { get; set; }

        /// <summary>
        /// Tổng tiền
        /// </summary>
        [Required]
        public double Amount { get; set; }
    }
}