namespace BrightFocus.Application.Command.MaterialWarehouse.ImportMaterialWarehouse
{
    public class ImportMaterialWarehouseCommandValidator
        : AbstractValidator<ImportMaterialWarehouseCommand>
    {
        public ImportMaterialWarehouseCommandValidator()
        {
            _ = RuleFor(x => x.File)
                .NotNull()
                .WithMessage("File không được để trống.");
        }
    }
}
