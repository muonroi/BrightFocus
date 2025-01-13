



namespace BrightFocus.Data.Query
{
    public class TaskImportExportQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<ImportExportTaskEntity>(dbContext, authContext), ITaskImportExportQuery
    {
        public async Task<TaskResponse?> GetImportExportTaskById(Guid entityId)
        {
            ImportExportTaskEntity? taskInfo = await Queryable.FirstOrDefaultAsync(x => x.EntityId == entityId);
            if (taskInfo is null)
            {
                return null;
            }
            List<ImportEntity> importEntities = dbContext.ImportEntities.Where(x => x.TaskId == entityId && !x.IsDeleted)?.ToList() ?? [];

            List<ExportEntity> exportEntities = dbContext.ExportEntities.Where(x => x.TaskId == entityId && !x.IsDeleted)?.ToList() ?? [];
            _ = Enum.TryParse(taskInfo.Source, out SourceImport sourceValue);
            TaskResponse result = new()
            {
                ImportExportTask = new ImportExportTaskResponse()
                {
                    EntityId = entityId,
                    TaskName = taskInfo.TaskName,
                    Employee = taskInfo.EmployeeName,
                    Ingredient = taskInfo.Ingredient,
                    Source = sourceValue,
                    Factory = taskInfo.FactoryName,
                    DeadlineDate = taskInfo.DeadlineDate.ToString(format: "dd/MM/yyyy"),
                    ProductsImport = importEntities.Select(x => new TaskMaterialResponse()
                    {
                        ProductName = x.ProductName,
                        Volume = x.Volume,
                        Ingredient = x.Ingredient,
                        Characteristic = x.Characteristic,
                        ColorCode = x.ColorCode,
                        FileNumber = x.FileNumber,
                        Warehouse = x.Warehouse,
                        OrderNumber = x.OrderNumber,
                        Note = x.Note,
                        Structure = x.Structure
                    }).ToList(),
                    ProductsExport = importEntities.Select(x => new TaskMaterialResponse()
                    {
                        ProductName = x.ProductName,
                        Volume = x.Volume,
                        Ingredient = x.Ingredient,
                        Characteristic = x.Characteristic,
                        ColorCode = x.ColorCode,
                        FileNumber = x.FileNumber,
                        Warehouse = x.Warehouse,
                        OrderNumber = x.OrderNumber,
                        Note = x.Note,
                        Structure = x.Structure
                    }).ToList(),
                }

            };
            return result;
        }
    }
}
