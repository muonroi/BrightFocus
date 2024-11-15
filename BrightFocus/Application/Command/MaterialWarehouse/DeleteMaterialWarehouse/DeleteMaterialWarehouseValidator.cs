namespace BrightFocus.Application.Command.MaterialWarehouse.DeleteMaterialWarehouse;

public class DeleteMaterialWarehouseValidator
    : AbstractValidator<DeleteMaterialWarehouseCommand>
{
    public DeleteMaterialWarehouseValidator()
    {
        _ = RuleFor(x => x.Id).NotEmpty();
    }
}
