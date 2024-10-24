namespace BrightFocus.Data.Repository;
public class FinishProductRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<FinishProduct>(dbContext, authContext), IFinishProductRepository
{
}
