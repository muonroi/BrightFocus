namespace BrightFocus.Application.Command.Task
{
    public class CreateTaskCommandValidator
        : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            _ = RuleFor(x => x.ProductName)
                .NotEmpty()
                .MaximumLength(100);

            _ = RuleFor(x => x.Material)
                .NotEmpty()
                .MaximumLength(100);

            _ = RuleFor(x => x.Size)
                .GreaterThan(0);

            _ = RuleFor(x => x.Weight)
                .GreaterThan(0);

            _ = RuleFor(x => x.Color)
                .NotEmpty()
                .MaximumLength(100);

            _ = RuleFor(x => x.Employee)
                .NotEmpty()
                .MaximumLength(100);

            _ = RuleFor(x => x.FactoryName)
                .NotEmpty()
                .MaximumLength(100);

            _ = RuleFor(x => x.Warehouse)
                .NotEmpty()
                .MaximumLength(100);

            _ = RuleFor(x => x.DeadlineDate)
                .NotEmpty();

            _ = RuleFor(x => x.Note)
                .MaximumLength(1000);

            _ = RuleFor(x => x.File)
                .MaximumLength(100);

            _ = RuleFor(x => x.TaskDetails)
                .NotEmpty();
        }
    }
}
