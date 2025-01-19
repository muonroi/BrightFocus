namespace BrightFocus.Core.Validators
{
    public class TaskMaterialRequestValidator : AbstractValidator<TaskMaterialRequest>
    {
        public TaskMaterialRequestValidator()
        {
            _ = RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Tên sản phẩm không được để trống.");

            _ = RuleFor(x => x.Ingredient)
                .NotEmpty().WithMessage("Nguyên liệu không được để trống.");

            _ = RuleFor(x => x.Characteristic)
                .NotEmpty().WithMessage("Đặc tính không được để trống.");

            _ = RuleFor(x => x.ColorCode)
                .NotEmpty().WithMessage("Mã màu không được để trống.");

            _ = RuleFor(x => x.FileNumber)
                .NotEmpty().WithMessage("Số tệp không được để trống.");

            _ = RuleFor(x => x.Volume)
                .GreaterThan(0).WithMessage("Khối lượng phải lớn hơn 0.");

            _ = RuleFor(x => x.Warehouse)
                .NotEmpty().WithMessage("Kho không được để trống.");

            _ = RuleFor(x => x.OrderNumber)
                .NotEmpty().WithMessage("Số đơn hàng không được để trống.");

            _ = RuleFor(x => x.Structure)
                .NotEmpty().WithMessage("Cấu trúc không được để trống.");
        }
    }
}
