﻿


namespace BrightFocus.Core.Models.Woods.Models
{
    public class WoodsInListDto : BaseModel
    {
        public string ClothId { get; set; } = string.Empty;
        public string ClothType { get; set; } = string.Empty;
        public int Weight { get; set; }
        public int Size { get; set; }
        public string Spindle { get; set; } = string.Empty;
        public int NumberOfCloth { get; set; }
        public int MeterOfCloth { get; set; }
        public string ManufacturingPlant { get; set; } = string.Empty;
        public string FactoryImport { get; set; } = string.Empty;
        public double ExportDateTs { get; set; }
        public double ImportDateTs { get; set; }
        public string ReceiptImport { get; set; } = string.Empty;
        public string ReceiptExport { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                _ = CreateMap<Wood, WoodsInListDto>();
                _ = CreateMap<Wood, WoodsListDto>();
            }
        }
    }
}