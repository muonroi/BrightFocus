namespace BrightFocus.Application.Command.Task.CustomerTask
{
    public class CustomerTaskCommandValidator : AbstractValidator<CustomerTaskCommand>
    {
        public CustomerTaskCommandValidator()
        {
            _ = RuleFor(x => x.TaskName)
                .NotEmpty().WithMessage("Tên công việc không được để trống.");

            _ = RuleFor(x => x.CustomerCode)
                .NotEmpty().WithMessage("Mã khách hàng không được để trống.");

            _ = RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Tên khách hàng không được để trống.");

            _ = RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Địa chỉ không được để trống.");

            _ = RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Số điện thoại không được để trống.")
                .Matches(@"^(\+84|0)\d{9,10}$").WithMessage("Số điện thoại phải bắt đầu bằng +84 hoặc 0 và có từ 10-11 chữ số.");

        }
    }
}
