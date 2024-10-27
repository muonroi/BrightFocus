






namespace BrightFocus.Data.Persistence
{
    public class BrightFocusDbContext : MDbContext
    {
        public DbSet<TaskList> TaskLists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public BrightFocusDbContext(DbContextOptions options)
            : base(options, new NoMediator())
        { }

        public BrightFocusDbContext(DbContextOptions options, IMediator mediator) : base(options, mediator)
        { }
    }
}
