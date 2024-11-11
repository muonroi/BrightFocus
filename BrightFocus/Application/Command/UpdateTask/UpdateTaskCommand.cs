



namespace BrightFocus.Application.Command.UpdateTask
{
    public class UpdateTaskCommand : CreateTaskCommand, IRequest<MResponse<bool>>
    {
        public Guid TaskId { get; set; }


    }
}
