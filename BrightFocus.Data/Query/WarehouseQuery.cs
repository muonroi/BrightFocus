namespace BrightFocus.Data.Query
{
    public class WarehouseQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<Warehouse>(dbContext, authContext), IWarehouseQuery
    {
    }
}
