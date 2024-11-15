
namespace BrightFocus.Core.Interfaces.Repository.Task;

public interface ITaskListRepository : IMRepository<TaskListEntity>
{
    System.Threading.Tasks.Task DeleteBatchAsync(IEnumerable<TaskListEntity> allTasks);
}
