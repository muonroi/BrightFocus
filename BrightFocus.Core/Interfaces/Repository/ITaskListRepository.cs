namespace BrightFocus.Core.Interfaces.Repository
{
    public interface ITaskListRepository : IMRepository<TaskList>
    {
        Task<MResponse<MPagedResult<TaskInListDto>>> GetTaskListPagingAsync(int pageIndex, int pageSize, string keyword);
    }
}
