namespace BrightFocus.Data.Repository
{
    public class TaskDetailRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
                : MRepository<TaskDetailEntity>(dbContext, authContext), ITaskDetailRepository
    {
    }
}
