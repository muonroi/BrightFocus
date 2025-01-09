

namespace BrightFocus.Data.Repository
{
    public class OrderExportRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
                : MRepository<OrderExportEntity>(dbContext, authContext), IOrderExportRepository
    {
    }
}
