

namespace BrightFocus.Application.Command.TaskCommand.ImportExportTask
{
    public class ImportExportTaskCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        IImportRepository taskImportRepository,
        IExportRepository taskExportRepositor,
        IImportExportTaskRepository importExportTaskRepository
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<ImportExportTaskCommand, MResponse<bool>>
    {
        public async Task<MResponse<bool>> Handle(ImportExportTaskCommand request, CancellationToken cancellationToken)
        {
            MResponse<bool> result = new();

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

            List<ImportEntity> productsImport = [];
            List<ExportEntity> productsExport = [];

            foreach (TaskMaterialRequest productImport in request.ProductsImport)
            {
                ImportEntity productImportData = Mapper.Map<ImportEntity>(productImport);
                productImportData.TaskId = taskId;
                productsImport.Add(productImportData);
            }

            foreach (TaskMaterialRequest productExport in request.ProductsExport)
            {
                ExportEntity productExportData = Mapper.Map<ExportEntity>(productExport);
                productExportData.TaskId = taskId;
                productsExport.Add(productExportData);
            }

            Task<int> importProductTask = taskImportRepository.AddBatchAsync(productsImport);

            Task<int> exportProductTask = taskExportRepositor.AddBatchAsync(productsExport);

            _ = await Task.WhenAll(importProductTask, exportProductTask);

            _ = await taskImportRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            _ = await taskExportRepositor.UnitOfWork.SaveChangesAsync(cancellationToken);

            result.Result = true;

            return result;
        }
    }
}
