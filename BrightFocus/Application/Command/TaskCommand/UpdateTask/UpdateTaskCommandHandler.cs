

namespace BrightFocus.Application.Command.TaskCommand.UpdateTask;

public class UpdateTaskCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    ITaskListRepository taskListRepository,
    ITaskListQuery taskListQuery,
    ITaskDetailRepository taskDetailRepository,
    ITaskDetailQuery taskDetailQuery,
    IDeliveryWarehouseRepository deliveryWarehouseRepository,
    IMJsonSerializeService mJsonSerializeService,
    IFileStorageService fileStorageService
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<UpdateTaskCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();

        TaskListEntity? existTask = await taskListQuery.GetByGuidAsync(request.EntityId ?? Guid.Empty);
        if (existTask is null)
        {
            result.StatusCode = StatusCodes.Status404NotFound;
            result.AddErrorMessage(nameof(AllTaskError.NotFound));
            return result;
        }

        _ = Mapper.Map(request, existTask);

        if (request.File != null)
        {
            existTask.FileUrl = await fileStorageService.SaveFileAsync(request.File, "uploads");
        }

        IEnumerable<TaskDetailDto> taskDetails = ParseTaskDetails(request.TaskDetails);

        await taskListRepository.ExecuteTransactionAsync(async () =>
        {
            await UpdateTaskAsync(existTask, taskDetails, request);

            result.Result = true;
            return result;
        });

        return result;
    }

    private IEnumerable<TaskDetailDto> ParseTaskDetails(string? taskDetailsJson)
    {
        IEnumerable<TaskDetailDto> taskDetails = string.IsNullOrEmpty(taskDetailsJson)
            ? []
            : mJsonSerializeService.Deserialize<IEnumerable<TaskDetailDto>>(taskDetailsJson) ?? [];

        return taskDetails;
    }

    private async Task UpdateTaskAsync(TaskListEntity existTask, IEnumerable<TaskDetailDto> taskDetails, UpdateTaskCommand request)
    {
        _ = taskListRepository.Update(existTask);

        IEnumerable<TaskDetailDto> taskDetailDtos = taskDetails as TaskDetailDto[] ?? taskDetails.ToArray();
        if (taskDetailDtos.Any())
        {
            List<TaskDetailEntity> existingTaskDetails = await taskDetailQuery.GetTaskDetailByTaskNoAsync(request.EntityId ?? Guid.Empty);
            await UpdateTaskDetails(existingTaskDetails, taskDetailDtos.ToList(), existTask.EntityId);
        }

        await CommitChangesAsync();
    }

    private async Task UpdateTaskDetails(
        List<TaskDetailEntity> existingTaskDetails,
        List<TaskDetailDto> taskDetails,
        Guid taskId)
    {
        HashSet<Guid?> requestDetailIds = taskDetails.Select(d => d.EntityId).ToHashSet();

        List<TaskDetailEntity> toDelete = existingTaskDetails
            .Where(detail => !requestDetailIds.Contains(detail.EntityId))
            .ToList();
        if (toDelete.Count != 0)
        {
            foreach (TaskDetailEntity? detail in toDelete)
            {
                _ = await taskDetailRepository.DeleteAsync(detail);
            }
        }

        foreach (TaskDetailDto detailDto in taskDetails)
        {
            TaskDetailEntity? matchedDetail = existingTaskDetails.FirstOrDefault(x => x.EntityId == detailDto.EntityId);
            if (matchedDetail != null)
            {
                _ = Mapper.Map(detailDto, matchedDetail);
                matchedDetail.TaskId = taskId;
                _ = taskDetailRepository.Update(matchedDetail);
            }
            else
            {
                TaskDetailEntity newDetail = Mapper.Map<TaskDetailEntity>(detailDto);
                newDetail.TaskId = taskId;
                _ = taskDetailRepository.Add(newDetail);
            }
        }
    }

    private async Task CommitChangesAsync()
    {
        _ = await taskListRepository.UnitOfWork.SaveChangesAsync();
        _ = await taskDetailRepository.UnitOfWork.SaveChangesAsync();
        _ = await deliveryWarehouseRepository.UnitOfWork.SaveChangesAsync();
    }
}
