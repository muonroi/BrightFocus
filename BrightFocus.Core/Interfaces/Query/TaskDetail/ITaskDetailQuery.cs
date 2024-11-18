namespace BrightFocus.Core.Interfaces.Query.TaskDetail;

public interface ITaskDetailQuery : IMQueries<TaskDetailEntity>
{
    Task<MResponse<MPagedResult<TaskDetailDto>>> GetTaskDetailPagingAsync(Guid taskId, int pageIndex, int pageSize, string keyword, string sortBy, string sortOrder);
    Task<List<TaskDetailEntity>> GetTaskDetailByTaskNoAsync(Guid taskId);
    Task<List<TaskDetailEntity>> GetTaskDetailsByTaskIdsAsync(List<Guid> foundTaskIds);
}
