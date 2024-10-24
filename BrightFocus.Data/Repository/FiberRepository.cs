namespace BrightFocus.Data.Repository;
public class FiberRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<Fiber>(dbContext, authContext), IFiberRepository
{
}
