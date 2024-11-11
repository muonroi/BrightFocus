

namespace BrightFocus.Data.Repository
{
    public class TaskDetailRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MRepository<TaskDetail>(dbContext, authContext), ITaskDetailRepository
    {
    }
}
