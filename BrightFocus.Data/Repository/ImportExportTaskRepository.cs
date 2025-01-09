namespace BrightFocus.Data.Repository
{
    public class ImportExportTaskRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
                : MRepository<ImportExportTaskEntity>(dbContext, authContext), IImportExportTaskRepository
    {
    }
}
