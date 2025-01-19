namespace BrightFocus.Core.Validators
{
    public class CreateOrUpdateTaskRequestValidator : AbstractValidator<CreateOrUpdateTaskRequest>
    {
        public CreateOrUpdateTaskRequestValidator()
        {
            _ = RuleFor(x => x.WrapperId)
                .GreaterThan(0).WithMessage("Mã bọc sản phẩm phải lớn hơn 0.");

            _ = RuleForEach(x => x.TaskProducts)
                .SetValidator(new TaskMaterialRequestValidator());

            _ = RuleForEach(x => x.TaskMaterials)
                .SetValidator(new TaskMaterialRequestValidator());

            _ = RuleFor(x => x.TaskProcesses)
                .NotNull().WithMessage("Quy trình công việc không được để trống.")
                .SetValidator(new TaskProcessRequestValidator());
        }
    }
}
