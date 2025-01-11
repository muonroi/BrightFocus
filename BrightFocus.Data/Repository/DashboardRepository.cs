namespace BrightFocus.Data.Repository
{
    public class DashboardRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MRepository<DashboardEntity>(dbContext, authContext), IDashboardRepository
    {
    }
}
