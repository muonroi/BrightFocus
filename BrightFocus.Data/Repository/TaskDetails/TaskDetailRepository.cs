






namespace BrightFocus.Data.Repository.TaskDetails;

public class TaskDetailRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MRepository<TaskDetailEntity>(dbContext, authContext), ITaskDetailRepository
{
    public async Task<bool> DeleteBatchAsync(List<TaskDetailEntity> taskDetails)
    {
        if (taskDetails == null || taskDetails.Count == 0)
        {
            throw new ArgumentException("The task details list cannot be null or empty.", nameof(taskDetails));
        }

        foreach (TaskDetailEntity taskDetail in taskDetails)
        {
            taskDetail.IsDeleted = true;
            taskDetail.DeletedDateTS = DateTime.UtcNow.GetTimeStamp(includedTimeValue: true);
            taskDetail.DeletedUserId = string.IsNullOrEmpty(CurrentUserId)
                ? null
                : new Guid?(Guid.Parse(CurrentUserId ?? Guid.Empty.ToString()));

            taskDetail.AddDomainEvent(new MEntityDeletedEvent<TaskDetailEntity>(taskDetail));

            _dbBaseContext.TrackEntity(taskDetail);
        }

        await _dbBaseContext.SaveChangesAsync();
        return true;

    }

}
