namespace BrightFocus.Application.Command.Task.OrderTask
{
    public class OrderTaskCommandValidator : AbstractValidator<OrderTaskCommand>
    {
        public OrderTaskCommandValidator()
        {
            _ = RuleFor(x => x.TaskName)
                .NotEmpty().WithMessage("Tên công việc không được để trống.");

            _ = RuleFor(x => x.CustomerCode)
                .NotEmpty().WithMessage("Mã khách hàng không được để trống.");

            _ = RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Tên khách hàng không được để trống.");

            _ = RuleFor(x => x.Employee)
                .NotEmpty().WithMessage("Tên nhân viên không được để trống.");

            _ = RuleFor(x => x.DeadlineDate)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Hạn chót phải lớn hơn thời điểm hiện tại.");

            _ = RuleForEach(x => x.Orders)
                 .SetValidator(new TaskMaterialRequestValidator());

            _ = RuleForEach(x => x.ExportOrders)
                .SetValidator(new TaskMaterialRequestValidator());
        }
    }
}
