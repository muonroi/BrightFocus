namespace BrightFocus.Data.Repository
{
    public class ProductMaterialRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
                : MRepository<ProductMaterialEntity>(dbContext, authContext), IProductMaterialRepository
    {
    }
}
