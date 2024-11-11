namespace BrightFocus.Application.Command.DeleteTaskDetail
{
    public class DeleteTaskDetailCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        ITaskDetailRepository taskDetailRepository)
            : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
              IRequestHandler<DeleteTaskDetailCommand, MResponse<bool>>
    {
        public async Task<MResponse<bool>> Handle(DeleteTaskDetailCommand request, CancellationToken cancellationToken)
        {
            MResponse<bool> result = new();
            List<Guid> notFoundIds = [];

            foreach (Guid taskId in request.TaskDetailIds)
            {
                TaskDetail? taskDetail = await taskDetailRepository.GetByGuidAsync(taskId);
                if (taskDetail == null)
                {
                    notFoundIds.Add(taskId);
                    continue;
                }
                _ = await taskDetailRepository.DeleteAsync(taskDetail);
            }

            if (notFoundIds.Count != 0)
            {
                result.StatusCode = StatusCodes.Status404NotFound;
                result.AddErrorMessage($"{notFoundIds.Count} {nameof(AllTaskError.NotFound)}");
                return result;
            }

            _ = await taskDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            result.Result = true;
            return result;
        }
    }
}
