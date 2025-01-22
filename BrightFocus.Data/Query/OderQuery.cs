namespace BrightFocus.Data.Query
{
    public class OderQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<OrderEntity>(dbContext, authContext), IOderQuery
    {
        public async Task<IEnumerable<TaskMaterialResponse>> GetOrderByCode(string code)
        {
            IQueryable<OrderEntity> orderInfo = Queryable.Where(x => x.OrderNumber == code);
            List<TaskMaterialResponse> orderResult = await orderInfo.Select(x => new TaskMaterialResponse
            {
                EntityId = x.EntityId,
                ProductName = x.ProductName,
                Material = x.Material,
                Ingredient = x.Ingredient,
                Characteristic = x.Characteristic,
                ColorCode = x.ColorCode,
                FileNumber = x.FileNumber,
                Volume = x.Volume,
                Price = x.Price,
                OrderNumber = x.OrderNumber,
                Note = x.Note,
                Structure = x.Structure,
                TotalAmount = x.Price * x.Volume
            }).ToListAsync();
            return orderResult;

        }
    }
}
