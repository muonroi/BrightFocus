namespace BrightFocus.Application.Command.TaskCommand.UpdateTask
{
    public class UpdateTaskCommandValidator
        : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
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

            _ = RuleFor(x => x.TaskDetails)
                .NotEmpty();
        }
    }
}
