

namespace BrightFocus.Data.Repository.DeliveryWarehouse
{
    public class DeliveryWarehouseRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
                : MRepository<DeliveryWarehouseEntity>(dbContext, authContext), IDeliveryWarehouseRepository
    {
    }
}
