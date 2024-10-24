






namespace BrightFocus.Data.SeedWorks
{
    public class UnitOfWork(BrightFocusDbContext context, MAuthenticateInfoContext authenticateInfoContext, IMapper mapper) : IUnitOfWork
    {
        private readonly BrightFocusDbContext _context = context;
        public ITaskListRepository TaskListRepository { get; private set; }
            = new TaskListRepository(context, authenticateInfoContext, mapper);

        public IChemicalsRepository ChemicalsRepository { get; private set; }
            = new ChemicalsRepository(context, authenticateInfoContext, mapper);

        public IFibersRepository FibersRepository { get; private set; }
            = new FibersRepository(context, authenticateInfoContext, mapper);

        public IFinishedProductRepository FinishedRepository { get; private set; }
            = new FinishedProductRepository(context, authenticateInfoContext, mapper);

        public IPaperTubeRepository PaperTubeRepository { get; private set; }
            = new PaperTubeRepository(context, authenticateInfoContext, mapper);

        public IWastesRepository WastesRepository { get; private set; }
            = new WastesRepository(context, authenticateInfoContext, mapper);

        public IWoodsRepository WoodsRepository { get; private set; }
            = new WoodsRepository(context, authenticateInfoContext, mapper);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
