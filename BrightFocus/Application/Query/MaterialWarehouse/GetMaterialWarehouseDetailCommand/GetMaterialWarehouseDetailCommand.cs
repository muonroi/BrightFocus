

namespace BrightFocus.Application.Query.MaterialWarehouse.GetMaterialWarehouseDetailCommand
{
    public class GetMaterialWarehouseDetailCommand :
        IRequest<MResponse<MaterialWarehousesDto>>
    {
        public Guid MaterialWarehouseId { get; set; }
    }
}
