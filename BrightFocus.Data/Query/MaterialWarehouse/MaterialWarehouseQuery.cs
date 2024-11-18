

namespace BrightFocus.Data.Query.MaterialWarehouse;

public class MaterialWarehouseQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<MaterialWarehouseEntity>(dbContext, authContext), IMaterialWarehouseQuery
{
    public async Task<MResponse<MPagedResult<MaterialWarehousesDto>>> GetMaterialListPagingAsync(int pageIndex, int pageSize, string keyword, string sortBy, string sortOrder)
    {
        MResponse<MPagedResult<MaterialWarehousesDto>> result = new();


        MPagedResult<MaterialWarehousesDto> pagedResult = await GetPagedAsync(
            Queryable,
            pageIndex,
            pageSize,
            materialWarehouse => new MaterialWarehousesDto()
            {
                EntityId = materialWarehouse.EntityId,
                ProductCode = materialWarehouse.ProductCode,
                ProductName = materialWarehouse.ProductName,
                Material = materialWarehouse.Material,
                Quantification = materialWarehouse.Quantification,
                UnitQuantification = materialWarehouse.UnitQuantification,
                Width = materialWarehouse.Width,
                UnitWidth = materialWarehouse.UnitWidth,
                Color = materialWarehouse.Color,
                Characteristic = materialWarehouse.Characteristic,
                Quantity = materialWarehouse.Quantity,
                UnitQuantity = materialWarehouse.UnitQuantity,
                Warehouse = materialWarehouse.Warehouse,
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
