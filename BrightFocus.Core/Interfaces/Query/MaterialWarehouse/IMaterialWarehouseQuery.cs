



namespace BrightFocus.Core.Interfaces.Query.MaterialWarehouse;

public interface IMaterialWarehouseQuery : IMQueries<MaterialWarehouseEntity>
{
    Task<MResponse<MPagedResult<MaterialWarehousesDto>>> GetMaterialListPagingAsync(
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
            string? warehouse);

}
