namespace BrightFocus.Core.Interfaces.Query.Task;

public interface ITaskListQuery : IMQueries<TaskListEntity>
{
    Task<MResponse<MPagedResult<TaskListDto>>> GetTaskListPagingAsync(int pageIndex, int pageSize, string keyword, string sortBy, string sortOrder);
    Task<IEnumerable<TaskListEntity>> GetTaskByGuidsAsync(List<Guid> guids);

}
