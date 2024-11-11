namespace BrightFocus.Application.Command.DeleteTask
{
    public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
    {
        public DeleteTaskCommandValidator()
        {
            _ = RuleFor(x => x.TaskIds).NotEmpty();
        }
    }
}
