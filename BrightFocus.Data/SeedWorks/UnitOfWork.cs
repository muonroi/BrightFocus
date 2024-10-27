namespace BrightFocus.Data.SeedWorks;

public class UnitOfWork(BrightFocusDbContext context,
    MAuthenticateInfoContext authContext,
    MAuthenticateTokenHelper<Permission> tokenHelper,
    MTokenInfo mTokenInfo, IMapper mapper) :
    IUnitOfWork, IDisposable
{
    private readonly BrightFocusDbContext _context = context;
    private bool _disposed = false;

    public ITaskListRepository TaskListRepository { get; private set; }
        = new TaskListRepository(context, authContext, mapper);

    public IAuthenticateRepository AuthenticateRepository { get; private set; }
    = new AuthenticateRepository<BrightFocusDbContext, Permission>(tokenHelper, context, authContext, mTokenInfo);

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    ~UnitOfWork()
    {
        Dispose(false);
    }
}
