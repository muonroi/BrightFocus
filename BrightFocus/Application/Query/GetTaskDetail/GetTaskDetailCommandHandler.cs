





namespace BrightFocus.Application.Query.GetTaskDetail
{
    public class GetTaskDetailCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        ITaskProductionQuery taskProductionQuery,
        ITaskImportExportQuery taskImportExportQuery,
        ITaskCustomerQuery taskCustomerQuery,
        ITaskOrderQuery taskOrderQuery
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<GetTaskDetailCommand, MResponse<TaskResponse>>
    {
        public async Task<MResponse<TaskResponse>> Handle(GetTaskDetailCommand request, CancellationToken cancellationToken)
        {
            MResponse<TaskResponse> result = new();
            TaskResponse? taskProductionData = request.TaskType switch
            {
                (int)TaskType.sx => await taskProductionQuery.GetProductionTaskById(request.EntityId),
                (int)TaskType.xn => await taskImportExportQuery.GetImportExportTaskById(request.EntityId),
                (int)TaskType.dh => await taskOrderQuery.GetOrderTaskById(request.EntityId),
                (int)TaskType.kh => await taskCustomerQuery.GetTaskCustomerByGuidAsync(request.EntityId),
                _ => null,
            };
            if (taskProductionData is null)
            {
                return result;
            }
            result.Result = taskProductionData;
            return result;
        }
    }
}