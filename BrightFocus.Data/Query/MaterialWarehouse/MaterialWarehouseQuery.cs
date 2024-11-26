



namespace BrightFocus.Data.Query.MaterialWarehouse;

public class MaterialWarehouseQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<MaterialWarehouseEntity>(dbContext, authContext), IMaterialWarehouseQuery
{
    public async Task<MResponse<MPagedResult<MaterialWarehousesDto>>> GetMaterialListPagingAsync(
            int pageIndex,
            int pageSize,
            string keyword,
            string sortBy,
            string sortOrder,
            string? productCode,
            string? productName,
            string? material,
            double? quantification,
            double? width,
            string? color,
            string? characteristic,
            double? quantity,
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

        if (width.HasValue)
        {
            query = query.Where(x => x.Width == width.Value);
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
                Width = materialWarehouse.Width,
                Color = materialWarehouse.Color,
                Factory = materialWarehouse.Factory,
                Characteristic = materialWarehouse.Characteristic,
                Quantity = materialWarehouse.Quantity,
                Warehouse = materialWarehouse.Warehouse,
                ReceiptNumber = materialWarehouse.ReceiptNumber,
                MaterialProductType = materialWarehouse.MaterialProductType,
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

    public async Task<bool> ExistsAsync(Expression<Func<MaterialWarehouseEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Queryable.AnyAsync(predicate, cancellationToken);
    }

}
