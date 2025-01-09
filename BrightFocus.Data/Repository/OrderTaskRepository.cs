namespace BrightFocus.Data.Repository
{
    public class OrderTaskRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
                : MRepository<TaskOrderEntity>(dbContext, authContext), IOrderTaskRepository
    {
    }
}
