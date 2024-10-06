






namespace BrightFocus.Data.SeedWorks
{
    public class UnitOfWork(BrightFocusDbContext context, MAuthenticateInfoContext authenticateInfoContext, IMapper mapper) : IUnitOfWork
    {
        private readonly BrightFocusDbContext _context = context;
        public ITaskListRepository TaskListRepository { get; private set; }
            = new TaskListRepository(context, authenticateInfoContext, mapper);

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
