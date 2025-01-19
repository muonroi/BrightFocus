namespace BrightFocus.Core.Interfaces.Query.ImportExportTask
{
    public interface ITaskImportQuery : IMQueries<ImportEntity>
    {
        Task<MPagedResult<TaskMaterialResponse>> GetWarehouseData(
            string productName,
            string ingredient,
            string structure,
            string characteristic,
            int pageIndex,
            int pageSize);
    }
}
