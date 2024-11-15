namespace BrightFocus.Application.Command.MaterialWarehouse.DeleteMaterialWarehouse;

public class DeleteMaterialWarehouseCommandHandler(IMapper mapper, MAuthenticateInfoContext tokenInfo, IAuthenticateRepository authenticateRepository, Serilog.ILogger logger, IMediator mediator, MPaginationConfig paginationConfig,
    IMaterialWarehouseRepository materialWarehouseRepository) :
    BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<DeleteMaterialWarehouseCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(DeleteMaterialWarehouseCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();
        List<Guid> notFoundIds = [];

        foreach (Guid taskId in request.Id)
        {
            MaterialWarehouseEntity? taskDetail = await materialWarehouseRepository.GetByGuidAsync(taskId);
            if (taskDetail == null)
            {
                notFoundIds.Add(taskId);
                continue;
            }
            _ = await materialWarehouseRepository.DeleteAsync(taskDetail);
        }

        if (notFoundIds.Count != 0)
        {
            result.StatusCode = StatusCodes.Status404NotFound;
            result.AddErrorMessage($"{notFoundIds.Count} {nameof(AllTaskError.NotFound)}");
            return result;
        }

        _ = await materialWarehouseRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        result.Result = true;
        return result;
    }
}
