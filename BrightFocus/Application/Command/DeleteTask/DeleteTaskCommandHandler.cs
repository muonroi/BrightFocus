



namespace BrightFocus.Application.Command.DeleteTask
{
    public class DeleteTaskCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        ITaskListRepository taskListRepository)
                : BaseCommandHandler(mapper,
                    tokenInfo,
                    authenticateRepository,
                    logger,
                    mediator,
                    paginationConfig),
        IRequestHandler<DeleteTaskCommand, MResponse<bool>>
    {
        public async Task<MResponse<bool>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            MResponse<bool> result = new();
            List<Guid> notFoundIds = [];

            foreach (Guid taskId in request.TaskIds)
            {
                TaskList? taskDetail = await taskListRepository.GetByGuidAsync(taskId);
                if (taskDetail == null)
                {
                    notFoundIds.Add(taskId);
                    continue;
                }
                _ = await taskListRepository.DeleteAsync(taskDetail);
            }

            if (notFoundIds.Count != 0)
            {
                result.StatusCode = StatusCodes.Status404NotFound;
                result.AddErrorMessage($"{notFoundIds.Count} {nameof(AllTaskError.NotFound)}");
                return result;
            }

            _ = await taskListRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            result.Result = true;
            return result;
        }
    }
}
