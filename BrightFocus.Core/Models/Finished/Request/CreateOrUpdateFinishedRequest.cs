

namespace BrightFocus.Core.Models.Finished.Request
{
    public class CreateOrUpdateFinishedRequest
    {
        public string ClothId { get; set; } = string.Empty;
        public string ClothType { get; set; } = string.Empty;
        public int Weight { get; set; }
        public string Spindle { get; set; } = string.Empty;
        public int Size { get; set; }
        public int NumberOfCloth { get; set; }
        public int MeterOfCloth { get; set; }
        public string ManufacturingPlant { get; set; } = string.Empty;
        public string FactoryImport { get; set; } = string.Empty;
        public double ExportDateTs { get; set; }
        public double ImportDateTs { get; set; }
        public string ReceiptImport { get; set; } = string.Empty;
        public string ReceiptExport { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                _ = CreateMap<CreateOrUpdateFinishedRequest, Domain.Inventory.FinishProduct>();
            }
        }
    }
}
