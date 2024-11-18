namespace BrightFocus.Application.Query.MaterialWarehouse.GetMaterialWarehouseDetailCommand
{
    public class GetMaterialWarehouseDetailCommandValidator
        : AbstractValidator<GetMaterialWarehouseDetailCommand>
    {
        public GetMaterialWarehouseDetailCommandValidator()
        {
            _ = RuleFor(x => x.MaterialWarehouseId)
                .NotEmpty()
                .WithMessage("MaterialWarehouseId is required");
        }
    }
}
