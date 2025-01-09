namespace BrightFocus.Data.Repository
{
    public class OrderRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
                : MRepository<OrderEntity>(dbContext, authContext), IOrderRepository
    {
    }
}
