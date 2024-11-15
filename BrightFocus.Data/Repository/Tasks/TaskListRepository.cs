

namespace BrightFocus.Data.Repository.Tasks;

public class TaskListRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
    : MRepository<TaskListEntity>(dbContext, authContext), ITaskListRepository
{
    public async Task DeleteBatchAsync(IEnumerable<TaskListEntity> allTasks)
    {
        if (allTasks == null || !allTasks.Any())
        {
            throw new ArgumentException("The task list cannot be null or empty.", nameof(allTasks));
        }

        foreach (TaskListEntity task in allTasks)
        {
            task.IsDeleted = true;
            task.DeletedDateTS = DateTime.UtcNow.GetTimeStamp(includedTimeValue: true);
            task.DeletedUserId = string.IsNullOrEmpty(CurrentUserId)
            ? null
                : new Guid?(Guid.Parse(CurrentUserId ?? Guid.Empty.ToString()));

            task.AddDomainEvent(new MEntityDeletedEvent<TaskListEntity>(task));

            _dbBaseContext.TrackEntity(task);
        }

        await _dbBaseContext.SaveChangesAsync();
    }
}
