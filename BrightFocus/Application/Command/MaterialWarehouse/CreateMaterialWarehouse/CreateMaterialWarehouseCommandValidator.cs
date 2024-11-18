namespace BrightFocus.Application.Command.MaterialWarehouse.CreateMaterialWarehouse;

public class CreateMaterialWarehouseCommandValidator
    : AbstractValidator<CreateMaterialWarehouseCommand>
{
    public CreateMaterialWarehouseCommandValidator()
    {
        // Validate ProductCode
        _ = RuleFor(command => command.ProductCode)
            .NotEmpty().WithMessage("Product code is required.")
            .MaximumLength(50).WithMessage("Product code must not exceed 50 characters.");
        // Validate ProductName
        _ = RuleFor(command => command.ProductName)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

        // Validate Material
        _ = RuleFor(command => command.Material)
            .NotEmpty().WithMessage("Material is required.")
            .MaximumLength(50).WithMessage("Material must not exceed 50 characters.");

        // Validate Quantification
        _ = RuleFor(command => command.Quantification)
            .GreaterThan(0).WithMessage("Quantification must be greater than 0.");

        // Validate UnitQuantification
        _ = RuleFor(command => command.UnitQuantification)
            .NotEmpty().WithMessage("Unit of quantification is required.");

        // Validate Width
        _ = RuleFor(command => command.Width)
            .GreaterThan(0).WithMessage("Width must be greater than 0.");

        // Validate UnitWidth
        _ = RuleFor(command => command.UnitWidth)
            .NotEmpty().WithMessage("Unit of width is required.");

        // Validate Color
        _ = RuleFor(command => command.Color)
            .MaximumLength(50).WithMessage("Color must not exceed 50 characters.");

        // Validate Characteristic
        _ = RuleFor(command => command.Characteristic)
            .MaximumLength(100).WithMessage("Characteristic must not exceed 100 characters.");

        // Validate Quantity
        _ = RuleFor(command => command.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

        // Validate UnitQuantity
        _ = RuleFor(command => command.UnitQuantity)
            .NotEmpty().WithMessage("Unit of quantity is required.");

        // Validate Factory
        _ = RuleFor(command => command.Factory)
            .MaximumLength(100).WithMessage("Factory name must not exceed 100 characters.");

        // Validate Warehouse
        _ = RuleFor(command => command.Warehouse)
            .MaximumLength(100).WithMessage("Warehouse name must not exceed 100 characters.");

        // Validate ReceiptNumber
        _ = RuleFor(command => command.ReceiptNumber)
            .NotEmpty().WithMessage("Receipt number is required.")
            .MaximumLength(50).WithMessage("Receipt number must not exceed 50 characters.");

        // Validate EntryDate
        _ = RuleFor(command => command.EntryDate)
            .NotEmpty().WithMessage("Entry date is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Entry date cannot be in the future.");

        // Validate FileNumber
        _ = RuleFor(command => command.FileNumber)
            .NotEmpty().WithMessage("File number is required.")
            .MaximumLength(50).WithMessage("File number must not exceed 50 characters.");
    }
}
