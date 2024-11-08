


namespace BrightFocus.Application.Command.Task
{
    public class CreateTaskCommandHandler(IMapper mapper,
        ITaskListRepository taskListRepository,
        ITaskDetailRepository taskDetailRepository
        ) :
        IRequestHandler<CreateTaskCommand, MResponse<bool>>
    {
        public async Task<MResponse<bool>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            MResponse<bool> result = new();

            // validate request
            TaskList taskEntity = mapper.Map<CreateTaskCommand, TaskList>(request);

            if (!taskEntity.IsValid())
            {
                result.StatusCode = StatusCodes.Status400BadRequest;
                result.AddResultFromErrorList(taskEntity.ErrorMessages);
                return result;
            }

            //save task to db
            await taskListRepository.ExecuteTransactionAsync(
                async () =>
                {
                    _ = taskListRepository.Add(taskEntity);
                    // save task details to db
                    if (request.TaskDetails != null)
                    {
                        foreach (TaskDetailDto taskDetail in request.TaskDetails)
                        {
                            TaskDetail taskDetailEntity = mapper.Map<TaskDetailDto, TaskDetail>(taskDetail);
                            taskDetailEntity.TaskId = taskEntity.EntityId;
                            _ = taskDetailRepository.Add(taskDetailEntity);
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
}
