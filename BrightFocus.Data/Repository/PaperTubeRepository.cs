namespace BrightFocus.Data.Repository;
public class PaperTubeRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<PaperTube>(dbContext, authContext), IPaperTubeRepository
{
}
