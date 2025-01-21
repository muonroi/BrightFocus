


namespace BrightFocus.Data.Query
{
    public class TaskProductionQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<TaskProductionEntity>(dbContext, authContext), ITaskProductionQuery
    {
        public async Task<TaskResponse?> GetProductionTaskById(Guid entityId)
        {
            TaskProductionEntity? taskInfo = await Queryable.FirstOrDefaultAsync(x => x.EntityId == entityId);
            if (taskInfo is null)
            {
                return null;
            }
            List<TaskDetailEntity> taskDetail = await dbContext.TaskDetailEntities.Where(x => x.TaskId == entityId && !x.IsDeleted).ToListAsync();

            List<ProductMaterialEntity> taskProductMaterial = await dbContext.ProductMaterialEntities.Where(x => x.TaskId == entityId && !x.IsDeleted).ToListAsync();

            List<ProductProcessEntity> taskProcess = await dbContext.ProcessProductEntities.Where(x => x.TaskId == entityId && !x.IsDeleted).ToListAsync();

            TaskResponse result = new()
            {
                ProductionTask = new ProductionTaskResponse()
                {
                    EntityId = entityId,
                    TaskName = taskInfo.TaskName,
                    Employee = taskInfo.EmployeeName,
                    Factory = taskInfo.FactoryName,
                    DeadlineDate = taskInfo.DeadlineDate.ToString(format: "dd/MM/yyyy"),
                    ProductWrappers = new CreateOrUpdateTaskResponse()
                    {
                        TaskProducts = taskDetail.Select(x => new TaskMaterialResponse()
                        {
                            ProductName = x.ProductName,
                            Volume = x.Volume,
                            Ingredient = x.Ingredient,
                            Characteristic = x.Characteristic,
                            ColorCode = x.ColorCode,
                            FileNumber = x.FileNumber,
                            Price = x.Price,
                            OrderNumber = x.OrderNumber,
                            Note = x.Note,
                            WrapperId = x.WrapperId,
                            Structure = x.Structure
                        }).ToList(),
                        TaskMaterials = taskProductMaterial.Select(x => new TaskMaterialResponse()
                        {
                            ProductName = x.ProductName,
                            Volume = x.Volume,
                            Ingredient = x.Ingredient,
                            Characteristic = x.Characteristic,
                            ColorCode = x.ColorCode,
                            FileNumber = x.FileNumber,
                            Factory = x.Factory,
                            OrderNumber = x.OrderNumber,
                            Note = x.Note,
                            WrapperId = x.WrapperId,
                            Structure = x.Structure
                        }).ToList(),
                        TaskProcesses = taskProcess.Select(process => new TaskProcessResponse()
                        {
                            StepOne = process.StepOne,
                            StepTwo = process.StepTwo,
                            StepThree = process.StepThree,
                            StepFour = process.StepFour,
                            StepFive = process.StepFive,
                            StepSix = process.StepSix,
                            StepSeven = process.StepSeven,
                            StepEight = process.StepEight,
                            WrapperId = process.WrapperId,
                            TaskId = process.TaskId
                        }).ToList(),
                    }
                }

            };
            return result;
        }
    }
}
