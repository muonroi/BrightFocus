





namespace BrightFocus.Data.Persistence;

public class BrightFocusDbContext : MDbContext
{
    public DbSet<DashboardEntity> DashboardEntities { get; set; }
    public DbSet<CustomerEntity> CustomerEntities { get; set; }
    public DbSet<ExportEntity> ExportEntities { get; set; }
    public DbSet<ImportEntity> ImportEntities { get; set; }
    public DbSet<OrderExportEntity> ExportOrderEntities { get; set; }

    public DbSet<OrderEntity> OrderEntities { get; set; }
    public DbSet<TaskOrderEntity> TaskOrderEntities { get; set; }
    public DbSet<ProductProcessEntity> ProcessProductEntities { get; set; }
    public DbSet<ProductMaterialEntity> ProductMaterialEntities { get; set; }
    public DbSet<TaskDetailEntity> TaskDetailEntities { get; set; }
    public DbSet<TaskProductionEntity> TaskProductionEntities { get; set; }
    public DbSet<ImportExportTaskEntity> ImportExportTaskEntities { get; set; }


    public BrightFocusDbContext(DbContextOptions options)
        : base(options, new NoMediator())
    { }

    public BrightFocusDbContext(DbContextOptions options, IMediator mediator) : base(options, mediator)
    { }
}
