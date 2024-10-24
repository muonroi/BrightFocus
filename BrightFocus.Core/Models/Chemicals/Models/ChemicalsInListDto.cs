

namespace BrightFocus.Core.Models.Chemicals.Models
{
    public class ChemicalsInListDto : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Uses { get; set; } = string.Empty;
        public int Volume { get; set; }
        public int Weight { get; set; }
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
                _ = CreateMap<Domain.Inventory.Chemicals, ChemicalsInListDto>();
                _ = CreateMap<Domain.Inventory.Chemicals, ChemicalsListDto>();
            }
        }
    }
}
