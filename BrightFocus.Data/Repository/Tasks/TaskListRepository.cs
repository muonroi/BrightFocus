

namespace BrightFocus.Data.Repository.Tasks;

public class TaskListRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
    : MRepository<TaskListEntity>(dbContext, authContext), ITaskListRepository
{
}
