namespace BrightFocus.Core.Interfaces.Query.ImportExportTask
{
    public interface ITaskImportQuery : IMQueries<ImportEntity>
    {
        Task<MPagedResult<TaskMaterialResponse>> GetWarehouseDataPagingAsync(
            int pageIndex,
            int pageSize);
        Task<MPagedResult<TaskMaterialResponse>> GetWarehouseDataUsesAsync(
            string productName,
            string ingredient,
            string structure,
            string characteristic,
            int pageIndex,
            int pageSize);
    }
}
