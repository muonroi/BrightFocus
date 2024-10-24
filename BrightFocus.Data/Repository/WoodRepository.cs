namespace BrightFocus.Data.Repository;
public class WoodRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<Wood>(dbContext, authContext), IWoodRepository
{
}
