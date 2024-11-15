namespace BrightFocus.Application.Command.MaterialWarehouse.CreateMaterialWarehouse;

public class CreateMaterialWarehouseCommandValidator
    : AbstractValidator<CreateMaterialWarehouseCommand>
{
    public CreateMaterialWarehouseCommandValidator()
    {
        // Validate ProductName
        RuleFor(command => command.ProductName)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

        // Validate Material
        RuleFor(command => command.Material)
            .NotEmpty().WithMessage("Material is required.")
            .MaximumLength(50).WithMessage("Material must not exceed 50 characters.");

        // Validate Quantification
        RuleFor(command => command.Quantification)
            .GreaterThan(0).WithMessage("Quantification must be greater than 0.");

        // Validate UnitQuantification
        RuleFor(command => command.UnitQuantification)
            .NotEmpty().WithMessage("Unit of quantification is required.");

        // Validate Width
        RuleFor(command => command.Width)
            .GreaterThan(0).WithMessage("Width must be greater than 0.");

        // Validate UnitWidth
        RuleFor(command => command.UnitWidth)
            .NotEmpty().WithMessage("Unit of width is required.");

        // Validate Color
        RuleFor(command => command.Color)
            .MaximumLength(50).WithMessage("Color must not exceed 50 characters.");

        // Validate Characteristic
        RuleFor(command => command.Characteristic)
            .MaximumLength(100).WithMessage("Characteristic must not exceed 100 characters.");

        // Validate Quantity
        RuleFor(command => command.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

        // Validate UnitQuantity
        RuleFor(command => command.UnitQuantity)
            .NotEmpty().WithMessage("Unit of quantity is required.");

        // Validate Factory
        RuleFor(command => command.Factory)
            .MaximumLength(100).WithMessage("Factory name must not exceed 100 characters.");

        // Validate Warehouse
        RuleFor(command => command.Warehouse)
            .MaximumLength(100).WithMessage("Warehouse name must not exceed 100 characters.");

        // Validate ReceiptNumber
        RuleFor(command => command.ReceiptNumber)
            .NotEmpty().WithMessage("Receipt number is required.")
            .MaximumLength(50).WithMessage("Receipt number must not exceed 50 characters.");

        // Validate EntryDate
        RuleFor(command => command.EntryDate)
            .NotEmpty().WithMessage("Entry date is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Entry date cannot be in the future.");

        // Validate FileNumber
        RuleFor(command => command.FileNumber)
            .NotEmpty().WithMessage("File number is required.")
            .MaximumLength(50).WithMessage("File number must not exceed 50 characters.");
    }
}
