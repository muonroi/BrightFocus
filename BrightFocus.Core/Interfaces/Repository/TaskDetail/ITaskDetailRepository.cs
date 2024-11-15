
namespace BrightFocus.Core.Interfaces.Repository.TaskDetail;

public interface ITaskDetailRepository : IMRepository<TaskDetailEntity>
{
    Task<bool> DeleteBatchAsync(List<TaskDetailEntity> taskDetails);
}
