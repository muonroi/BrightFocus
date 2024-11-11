namespace BrightFocus.Application.Query.Task.GetTaskDetail
{
    public class GetTaskDetailCommandValidator : AbstractValidator<GetTaskDetailCommand>
    {
        public GetTaskDetailCommandValidator()
        {
            _ = RuleFor(x => x.TaskId).NotEmpty();
        }
    }
}
