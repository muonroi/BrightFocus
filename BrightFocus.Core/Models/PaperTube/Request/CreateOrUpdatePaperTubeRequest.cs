

namespace BrightFocus.Core.Models.PaperTube.Request
{
    public class CreateOrUpdatePaperTubeRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public double Vat { get; set; }
        public decimal UnitPriceVat { get; set; }
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
                _ = CreateMap<CreateOrUpdatePaperTubeRequest, Domain.Inventory.PaperTube>();
            }
        }
    }
}
