namespace BrightFocus.Data.SeedWorks;

public class UnitOfWork(BrightFocusDbContext context, MAuthenticateInfoContext authenticateInfoContext, IMapper mapper) :
    IUnitOfWork, IDisposable
{
    private readonly BrightFocusDbContext _context = context;
    public ITaskListRepository TaskListRepository { get; private set; }
        = new TaskListRepository(context, authenticateInfoContext, mapper);
    public IChemicalsRepository ChemicalsRepositorys { get; private set; }
        = new ChemicalsRepository(context, authenticateInfoContext, mapper);
    public IFiberRepository FiberRepositorys { get; private set; }
        = new FiberRepository(context, authenticateInfoContext, mapper);
    public IFinishProductRepository FinishProductRepositorys { get; private set; }
        = new FinishProductRepository(context, authenticateInfoContext, mapper);
    public IPaperTubeRepository PaperTubeRepositorys { get; private set; }
        = new PaperTubeRepository(context, authenticateInfoContext, mapper);
    public IWasteProductRepository WasteProductRepositorys { get; private set; }
        = new WasteProductRepository(context, authenticateInfoContext, mapper);
    public IWoodRepository WoodRepositorys { get; private set; }
        = new WoodRepository(context, authenticateInfoContext, mapper);

    private bool _disposed = false;

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
                _context?.Dispose();
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
