namespace BrightFocus.Data.Repository;
public class WasteProductRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<WasteProduct>(dbContext, authContext), IWasteProductRepository
{
}
