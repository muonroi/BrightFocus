namespace BrightFocus.Core.Interfaces.Query
{
    public interface ITaskDetailQuery : IMQueries<TaskDetail>
    {
        Task<MPagedResult<TaskDetailDto>> GetTaskDetailPagingAsync(Guid taskId, int pageIndex, int pageSize, string keyword, string sortBy, string sortOrder);
        Task<List<TaskDetail>?> GetTaskDetailByTaskNoAsync(Guid taskId);
    }
}
