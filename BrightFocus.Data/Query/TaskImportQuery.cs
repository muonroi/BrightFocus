


namespace BrightFocus.Data.Query
{
    public class TaskImportQuery(MDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<ImportEntity>(dbContext, authContext), ITaskImportQuery
    {
        public async Task<MPagedResult<TaskMaterialResponse>> GetWarehouseData(
            string productName,
            string ingredient,
            string structure,
            string characteristic,
            int pageIndex,
            int pageSize)
        {
            IQueryable<ImportEntity> query = Queryable.AsQueryable();

            if (!string.IsNullOrEmpty(productName))
            {
                query = query.Where(x => x.ProductName.Contains(productName));
            }

            if (!string.IsNullOrEmpty(ingredient))
            {
                query = query.Where(x => x.Ingredient.Contains(ingredient));
            }

            if (!string.IsNullOrEmpty(structure))
            {
                query = query.Where(x => x.Structure.Contains(structure));
            }

            if (!string.IsNullOrEmpty(characteristic))
            {
                query = query.Where(x => x.Characteristic.Contains(characteristic));
            }

            IQueryable<TaskMaterialResponse> groupedQuery = query
                .GroupBy(x => new { x.ProductName, x.Ingredient, x.Structure, x.Characteristic })
                .Select(group =>
                new TaskMaterialResponse
                {

                    ProductName = group.Key.ProductName,
                    Ingredient = group.Key.Ingredient,
                    Structure = group.Key.Structure,
                    Characteristic = group.Key.Characteristic,
                    Details = group.Select(x => new TaskMaterialResponse
                    {
                        EntityId = x.EntityId,
                        ProductName = x.ProductName,
                        Material = x.Material,
                        Ingredient = x.Ingredient,
                        Characteristic = x.Characteristic,
                        ColorCode = x.ColorCode,
                        FileNumber = x.FileNumber,
                        Volume = x.Volume,
                        Warehouse = x.Warehouse,
                        OrderNumber = x.OrderNumber,
                        Note = x.Note,
                        Structure = x.Structure
                    }).ToList()
                });

            groupedQuery = groupedQuery.Select(x => new TaskMaterialResponse
            {
                ProductName = x.ProductName,
                Ingredient = x.Ingredient,
                Structure = x.Structure,
                Characteristic = x.Characteristic,
                Details = x.Details != null ? x.Details.Where(detail => detail.EntityId != x.EntityId).Select(detail => detail) : null
            });

            MPagedResult<TaskMaterialResponse> pagedResult = await GetListPagingForResponse(groupedQuery, pageIndex, pageSize);

            return new MPagedResult<TaskMaterialResponse>
            {
                CurrentPage = pagedResult.CurrentPage,
                PageSize = pagedResult.PageSize,
                RowCount = pagedResult.RowCount,
                Items = pagedResult.Items
            };
        }

        private static async Task<MPagedResult<TaskMaterialResponse>> GetListPagingForResponse(
                 IQueryable<TaskMaterialResponse> query,
                 int page,
                 int pageSize)
        {
            int totalItems = await query.CountAsync().ConfigureAwait(false);
            List<TaskMaterialResponse> items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync()
                .ConfigureAwait(false);

            return new MPagedResult<TaskMaterialResponse>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = totalItems,
                Items = items
            };
        }
    }
}
