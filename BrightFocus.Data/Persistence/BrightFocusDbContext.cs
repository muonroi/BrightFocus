namespace BrightFocus.Data.Persistence;

public class BrightFocusDbContext : MDbContext
{
    public DbSet<TaskListEntity> TaskLists { get; set; }
    public DbSet<TaskDetailEntity> TaskDetails { get; set; }
    public DbSet<MaterialWarehouseEntity> MaterialWarehouses { get; set; }
    public DbSet<WarehouseEntity> Warehouses { get; set; }

    public BrightFocusDbContext(DbContextOptions options)
        : base(options, new NoMediator())
    { }

    public BrightFocusDbContext(DbContextOptions options, IMediator mediator) : base(options, mediator)
    { }
}
