namespace BrightFocus.Application.Command.TaskCommand.ProductionTask
{
    public class ProductionTaskCommandValidator : AbstractValidator<ProductionTaskCommand>
    {
        public ProductionTaskCommandValidator()
        {
            _ = RuleFor(x => x.TaskName)
                .NotEmpty().WithMessage("Tên công việc không được để trống.");

            _ = RuleFor(x => x.Employee)
                .NotEmpty().WithMessage("Tên nhân viên không được để trống.");

            _ = RuleFor(x => x.Factory)
                .NotEmpty().WithMessage("Tên nhà máy không được để trống.");

            _ = RuleFor(x => x.DeadlineDate)
                .GreaterThan(DateTime.Now).WithMessage("Hạn chót phải lớn hơn thời điểm hiện tại.");

            _ = RuleForEach(x => x.ProductWrappers)
                .SetValidator(new CreateOrUpdateTaskRequestValidator());
        }
    }
}
