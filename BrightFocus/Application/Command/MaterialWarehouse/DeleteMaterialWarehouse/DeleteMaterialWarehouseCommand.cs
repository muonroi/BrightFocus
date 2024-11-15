namespace BrightFocus.Application.Command.MaterialWarehouse.DeleteMaterialWarehouse;

public class DeleteMaterialWarehouseCommand : IRequest<MResponse
    <bool>>
{
    public IEnumerable<Guid> Id { get; set; } = [];
}
