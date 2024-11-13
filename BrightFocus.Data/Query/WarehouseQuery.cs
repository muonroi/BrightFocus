namespace BrightFocus.Data.Query
{
    public class WarehouseQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<InventoryItem>(dbContext, authContext), IWarehouseQuery
    {
    }
}
