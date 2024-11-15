

namespace BrightFocus.Data.Repository.MaterialWarehouse;
public class MaterialWarehouseRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MRepository<MaterialWarehouseEntity>(dbContext, authContext), IMaterialWarehouseRepository
{
}
