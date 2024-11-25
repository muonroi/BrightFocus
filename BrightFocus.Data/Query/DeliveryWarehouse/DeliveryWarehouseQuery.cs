

namespace BrightFocus.Data.Query.DeliveryWarehouse
{
    public class DeliveryWarehouseQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<DeliveryWarehouseEntity>(dbContext, authContext),
        IDeliveryWarehouseQuery
    {
    }
}
