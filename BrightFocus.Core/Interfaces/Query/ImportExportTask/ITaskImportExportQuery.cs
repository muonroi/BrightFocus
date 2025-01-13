namespace BrightFocus.Core.Interfaces.Query.ImportExportTask
{
    public interface ITaskImportExportQuery : IMQueries<ImportExportTaskEntity>
    {
        Task<TaskResponse?> GetImportExportTaskById(Guid entityId);

    }
}
