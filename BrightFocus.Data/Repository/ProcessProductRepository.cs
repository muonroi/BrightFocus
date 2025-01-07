






namespace BrightFocus.Data.Repository
{
    public class ProcessProductRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
                : MRepository<ProductProcessEntity>(dbContext, authContext), IProcessProductRepository
    {
    }
}
