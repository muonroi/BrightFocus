namespace BrightFocus.Application.Command.Task.ImportExportTask
{
    public class ImportExportTaskCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        IImportRepository taskImportRepository,
        IExportRepository taskExportRepository,
        IImportExportTaskRepository importExportTaskRepository,
        IDashboardRepository dashboardRepository
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<ImportExportTaskCommand, MResponse<bool>>
    {
        public async Task<MResponse<bool>> Handle(ImportExportTaskCommand request, CancellationToken cancellationToken)
        {
            MResponse<bool> result = new();

            List<ImportEntity> productsImport = [];
            List<ExportEntity> productsExport = [];

            ImportExportTaskEntity taskProductEntity = new()
            {
                TaskName = request.TaskName,
                Ingredient = request.Ingredient,
                Source = request.Source.ToString(),
                EmployeeName = request.Employee,
                FactoryName = request.Factory,
                DeadlineDate = request.DeadlineDate,
            };

            _ = importExportTaskRepository.Add(taskProductEntity);
            _ = await importExportTaskRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            Guid taskId = taskProductEntity.EntityId;

            foreach (TaskMaterialRequest productImport in request.ProductsImport)
            {
                ImportEntity importEntity = MapImportEntity(productImport, taskId);
                productsImport.Add(importEntity);
            }

            foreach (TaskMaterialRequest productExport in request.ProductsExport)
            {
                ExportEntity exportEntity = MapExportEntity(productExport, taskId);
                productsExport.Add(exportEntity);
            }

            DashboardEntity dashboard = new()
            {
                TaskId = taskId,
                TaskName = request.TaskName,
                DeadlineDate = request.DeadlineDate,
                Employee = request.Employee,
                Factory = request.Factory,
                TaskType = TaskType.xn
            };

            await importExportTaskRepository.ExecuteTransactionAsync(async () =>
            {
                _ = await taskImportRepository.AddBatchAsync(productsImport);
                _ = await taskExportRepository.AddBatchAsync(productsExport);
                _ = dashboardRepository.Add(dashboard);

                _ = await taskImportRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                _ = await taskExportRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                _ = await dashboardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

                return result;
            });

            result.Result = true;
            return result;
        }

        private static ImportEntity MapImportEntity(TaskMaterialRequest product, Guid taskId)
        {
            return new ImportEntity
            {
                ProductName = product.ProductName,
                Ingredient = product.Ingredient,
                Characteristic = product.Characteristic,
                ColorCode = product.ColorCode,
                FileNumber = product.FileNumber,
                Volume = product.Volume,
                Warehouse = product.Warehouse,
                OrderNumber = product.OrderNumber,
                Note = product.Note,
                TaskId = taskId,
                Structure = product.Structure
            };
        }

        private static ExportEntity MapExportEntity(TaskMaterialRequest product, Guid taskId)
        {
            return new ExportEntity
            {
                ProductName = product.ProductName,
                Ingredient = product.Ingredient,
                Characteristic = product.Characteristic,
                ColorCode = product.ColorCode,
                FileNumber = product.FileNumber,
                Volume = product.Volume,
                Warehouse = product.Warehouse,
                OrderNumber = product.OrderNumber,
                Note = product.Note,
                TaskId = taskId,
                Structure = product.Structure
            };
        }
    }
}
