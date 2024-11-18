






namespace BrightFocus.Data.Repository.TaskDetails;

public class TaskDetailRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MRepository<TaskDetailEntity>(dbContext, authContext), ITaskDetailRepository
{

}
