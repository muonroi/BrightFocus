

namespace BrightFocus.Core.Interfaces.Repository
{
    public interface ITaskDetailRepository : IMRepository<TaskDetail>
    {
        Task<MResponse<MPagedResult<TaskDetailInListDto>>> GetTaskListPagingAsync(Guid taskId, int pageIndex, int pageSize, string keyword);
    }
}
