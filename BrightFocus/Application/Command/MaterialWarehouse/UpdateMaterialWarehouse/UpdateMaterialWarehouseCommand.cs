namespace BrightFocus.Application.Command.MaterialWarehouse.UpdateMaterialWarehouse;

public class UpdateMaterialWarehouseCommand : CreateOrUpdateMaterialWarehousesRequest, IRequest<MResponse<bool>>, IMapFrom<MaterialWarehouseEntity>
{
    public Guid TaskId { get; set; }
}
