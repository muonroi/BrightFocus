

namespace BrightFocus.Data.Query.MaterialWarehouse;

public class MaterialWarehouseQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<MaterialWarehouseEntity>(dbContext, authContext), IMaterialWarehouseQuery
{
    public async Task<MResponse<MPagedResult<MaterialWarehousesDto>>> GetMaterialListPagingAsync(int pageIndex, int pageSize, string keyword, string sortBy, string sortOrder)
    {
        MResponse<MPagedResult<MaterialWarehousesDto>> result = new();

        IQueryable<MaterialWarehouseEntity> query = dbContext.MaterialWarehouses.AsQueryable();

        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(x => x.ProductName.Contains(keyword));
        }

        int rowCount = await query.CountAsync();

        IQueryable<MaterialWarehouseEntity> items = query
            .OrderBy(x => x.ProductName)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);

        List<MaterialWarehousesDto> taskListDtos = await items
       .Select(materialWarehouse => new MaterialWarehousesDto()
       {
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
       }).ToListAsync();

        MPagedResult<MaterialWarehousesDto> data = new()
        {
            CurrentPage = pageIndex,
            PageSize = pageSize,
            RowCount = rowCount,
            Items = taskListDtos
        };
        result.Result = data;
        return result;
    }
}
