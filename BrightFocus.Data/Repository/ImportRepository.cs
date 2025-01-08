

namespace BrightFocus.Data.Repository
{
    public class ImportRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
                : MRepository<ImportEntity>(dbContext, authContext), IImportRepository
    {
    }
}
