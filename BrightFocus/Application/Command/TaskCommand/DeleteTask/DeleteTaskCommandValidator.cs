namespace BrightFocus.Application.Command.TaskCommand.DeleteTask;

public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        _ = RuleFor(x => x.TaskIds).NotEmpty();
    }
}
