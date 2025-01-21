namespace BrightFocus.Application.Query.GetWarehousePaging
{
    public class GetWarehousePagingCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        ITaskImportQuery taskImportQuery
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<GetWarehousePagingCommand, MResponse<MPagedResult<TaskMaterialResponse>>>
    {
        public async Task<MResponse<MPagedResult<TaskMaterialResponse>>> Handle(GetWarehousePagingCommand request, CancellationToken cancellationToken)
        {
            MResponse<MPagedResult<TaskMaterialResponse>> result = new();

            MPagedResult<TaskMaterialResponse> data = await taskImportQuery.GetWarehouseDataPagingAsync(
               request.PageIndex,
                PaginationConfig.DefaultPageSize
            );
            result.Result = data;
            return result;
        }
    }
}