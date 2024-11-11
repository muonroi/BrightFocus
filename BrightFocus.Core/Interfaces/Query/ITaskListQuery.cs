namespace BrightFocus.Core.Interfaces.Query
{
    public interface ITaskListQuery : IMQueries<TaskList>
    {
        Task<MResponse<MPagedResult<TaskListDto>>> GetTaskListPagingAsync(int pageIndex, int pageSize, string keyword, string sortBy, string sortOrder);
    }
}
