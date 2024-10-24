

namespace BrightFocus.Core.Models.Fibers.Request
{
    public class CreateOrUpdateFiberRequest
    {
        public string ProductId { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Index { get; set; } = string.Empty;
        public string ColorCode { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int Volume { get; set; }
        public int TotalVolume { get; set; }
        public string FactoryName { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public string ReceiptImport { get; set; } = string.Empty;
        public string ReceiptExport { get; set; } = string.Empty;
        public string FactoryImport { get; set; } = string.Empty;
        public string FactoryExport { get; set; } = string.Empty;
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                _ = CreateMap<CreateOrUpdateFiberRequest, Domain.Inventory.Fiber>();
            }
        }
    }
}
