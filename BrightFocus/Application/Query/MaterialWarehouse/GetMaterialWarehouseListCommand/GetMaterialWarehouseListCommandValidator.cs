namespace BrightFocus.Application.Query.MaterialWarehouse.GetMaterialWarehouseListCommand
{
    public class GetMaterialWarehouseListCommandValidator :
        AbstractValidator<GetMaterialWarehouseListCommand>
    {
        public GetMaterialWarehouseListCommandValidator()
        {
            _ = RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageIndex must be greater than or equal to 1");
            _ = RuleFor(x => x.SortBy)
                .NotEmpty()
                .WithMessage("SortBy is required");
            _ = RuleFor(x => x.SortOrder)
                .NotEmpty()
                .WithMessage("SortOrder is required");
        }
    }
}
