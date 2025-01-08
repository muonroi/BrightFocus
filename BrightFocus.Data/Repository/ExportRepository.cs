namespace BrightFocus.Data.Repository
{
    public class ExportRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
                : MRepository<ExportEntity>(dbContext, authContext), IExportRepository
    {
    }
}
