namespace BrightFocus.Application.Command.TaskCommand.UpdateTask;

public class UpdateTaskCommandHandler(IMapper mapper, MAuthenticateInfoContext tokenInfo, IAuthenticateRepository authenticateRepository, Serilog.ILogger logger, IMediator mediator, MPaginationConfig paginationConfig,
    ITaskListRepository taskListRepository,
    ITaskListQuery taskListQuery,
    ITaskDetailRepository taskDetailRepository,
    ITaskDetailQuery taskDetailQuery) :
    BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<UpdateTaskCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();

        TaskListEntity taskEntity = Mapper.Map<TaskListEntity>(request);
        if (!taskEntity.IsValid())
        {
            result.StatusCode = StatusCodes.Status400BadRequest;
            result.AddResultFromErrorList(taskEntity.ErrorMessages);
            return result;
        }
        if (request.EntityId is null)
        {
            result.StatusCode = StatusCodes.Status400BadRequest;
            result.AddResultFromErrorList(taskEntity.ErrorMessages);
            return result;
        }

        TaskListEntity? existTask = await taskListQuery.GetByGuidAsync(request.EntityId ?? Guid.Empty);
        if (existTask is null)
        {
            result.StatusCode = StatusCodes.Status404NotFound;
            result.AddErrorMessage(nameof(AllTaskError.NotFound));
            return result;
        }

        _ = Mapper.Map(request, existTask);

        await taskListRepository.ExecuteTransactionAsync(async () =>
        {
            _ = taskListRepository.Update(existTask);

            if (request.TaskDetails is not null)
            {
                List<TaskDetailEntity>? existingTaskDetails = await taskDetailQuery.GetTaskDetailByTaskNoAsync(request.EntityId ?? Guid.Empty);
                existingTaskDetails ??= [];

                List<Guid?> requestDetailIds = request.TaskDetails.Select(d => d.EntityId).ToList();

                List<TaskDetailEntity> toDelete = existingTaskDetails
                    .Where(detail => !requestDetailIds.Contains(detail.EntityId))
                    .ToList();

                foreach (TaskDetailEntity detailToDelete in toDelete)
                {
                    _ = taskDetailRepository.DeleteAsync(detailToDelete);
                }

                foreach (TaskDetailDto detailDto in request.TaskDetails)
                {
                    TaskDetailEntity? matchedDetail = existingTaskDetails.FirstOrDefault(x => x.EntityId == detailDto.EntityId);

                    if (matchedDetail is not null)
                    {
                        _ = Mapper.Map(detailDto, matchedDetail);
                        matchedDetail.TaskId = existTask.EntityId;
                        _ = taskDetailRepository.Update(matchedDetail);
                    }
                    else
                    {
                        TaskDetailEntity newDetail = Mapper.Map<TaskDetailEntity>(detailDto);
                        newDetail.TaskId = existTask.EntityId;
                        _ = taskDetailRepository.Add(newDetail);
                    }
                }
            }

            _ = await taskDetailRepository.UnitOfWork.SaveChangesAsync();
            _ = await taskListRepository.UnitOfWork.SaveChangesAsync();

            result.Result = true;
            return result;
        });

        return result;
    }


}
