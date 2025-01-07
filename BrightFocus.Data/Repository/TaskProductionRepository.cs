namespace BrightFocus.Data.Repository
{
    public class TaskProductionRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
                : MRepository<TaskProductionEntity>(dbContext, authContext), ITaskProductionRepository
    {
    }
}
