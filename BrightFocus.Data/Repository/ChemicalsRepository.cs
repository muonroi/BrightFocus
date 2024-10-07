namespace BrightFocus.Data.Repository;
public class ChemicalsRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<Chemicals>(dbContext, authContext), IChemicalsRepository
{
}
