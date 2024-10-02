




namespace BrightFocus.Data.Persistance
{
    public class BrightFocusDbContext : MDbContext
    {
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Wood> Woods { get; set; }
        public DbSet<WasteProduct> WasteProducts { get; set; }
        public DbSet<Chemicals> Chemicals { get; set; }
        public DbSet<Fiber> Fibers { get; set; }
        public DbSet<PaperTube> PaperTubes { get; set; }
        public DbSet<FinishProduct> FinishProducts { get; set; }

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
