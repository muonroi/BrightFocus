








namespace BrightFocus.Data.Repository;

public class TaskListRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MRepository<TaskList>(dbContext, authContext), ITaskListRepository
{


}
