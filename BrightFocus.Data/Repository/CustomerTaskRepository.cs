

namespace BrightFocus.Data.Repository
{
    public class CustomerTaskRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
                : MRepository<CustomerEntity>(dbContext, authContext), ICustomerTaskRepository
    {
    }
}
