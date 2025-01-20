


namespace BrightFocus.Data.Query
{
    public class TaskImportQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<ImportEntity>(dbContext, authContext), ITaskImportQuery
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

            bool noFilterApplied = string.IsNullOrEmpty(productName) &&
                         string.IsNullOrEmpty(ingredient) &&
                         string.IsNullOrEmpty(structure) &&
                         string.IsNullOrEmpty(characteristic);

            if (noFilterApplied)
            {
                return new MPagedResult<TaskMaterialResponse>
                {
                    CurrentPage = pageIndex,
                    PageSize = pageSize,
                    RowCount = 0,
                    Items = []
                };
            }

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
                .Select(x =>
                new TaskMaterialResponse
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
                }).Where(x => x.Volume > 0);

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
