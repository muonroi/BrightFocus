



namespace BrightFocus.Data.Query.MaterialWarehouse;

public class MaterialWarehouseQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<MaterialWarehouseEntity>(dbContext, authContext), IMaterialWarehouseQuery
{
    public async Task<MResponse<MPagedResult<MaterialWarehousesDto>>> GetMaterialListPagingAsync(
            int pageIndex,
            int pageSize,
            string keyword,
            string sortBy,
            string sortOrder,
            string? productName,
            string? material,
            double? quantification,
            string? color,
            string? characteristic,
            string? warehouse)
    {
        MResponse<MPagedResult<MaterialWarehousesDto>> result = new();

        IQueryable<MaterialWarehouseEntity> query = Queryable;

        if (!string.IsNullOrWhiteSpace(productName))
        {
            query = query.Where(x => x.ProductName.Contains(productName));
        }

        if (!string.IsNullOrWhiteSpace(material))
        {
            query = query.Where(x => x.Material.Contains(material));
        }

        if (quantification.HasValue)
        {
            query = query.Where(x => x.Quantification == quantification.Value);
        }

        if (!string.IsNullOrWhiteSpace(color))
        {
            query = query.Where(x => x.Color.Contains(color));
        }

        if (!string.IsNullOrWhiteSpace(characteristic))
        {
            query = query.Where(x => x.Characteristic.Contains(characteristic));
        }

        if (!string.IsNullOrWhiteSpace(warehouse))
        {
            query = query.Where(x => x.Warehouse.Contains(warehouse));
        }

        MPagedResult<MaterialWarehousesDto> pagedResult = await GetPagedAsync(
            query,
            pageIndex,
            pageSize,
            materialWarehouse => new MaterialWarehousesDto()
            {
                EntityId = materialWarehouse.EntityId,
                ProductCode = materialWarehouse.ProductCode,
                ProductName = materialWarehouse.ProductName,
                Material = materialWarehouse.Material,
                Quantification = materialWarehouse.Quantification,
                Color = materialWarehouse.Color,
                Characteristic = materialWarehouse.Characteristic,
                Quantity = materialWarehouse.Quantity,
                Warehouse = materialWarehouse.Warehouse,
                ReceiptNumber = materialWarehouse.ReceiptNumber,
                MaterialProductType = materialWarehouse.MaterialProductType,
                Note = materialWarehouse.Note,
                CreatedDate = materialWarehouse.CreationTime,
                FileNumber = materialWarehouse.FileNumber,
                Volume = materialWarehouse.Volume,
                Price = materialWarehouse.Price,
                Amount = materialWarehouse.Amount


            },
            keyword,
            x => string.IsNullOrEmpty(keyword) || x.ProductName.Contains(keyword),
            queryable =>
            {
                string validSortBy = string.IsNullOrWhiteSpace(sortBy) ? "CreationTime" : sortBy;
                return sortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase)
                    ? queryable.OrderByDescending(x => EF.Property<object>(x, validSortBy))
                    : queryable.OrderBy(x => EF.Property<object>(x, validSortBy));
            });

        result.Result = pagedResult;
        return result;
    }
}
