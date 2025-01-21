namespace BrightFocus.Application.Command.Task.ProductionTask
{
    public class ProductionTaskCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    ITaskProductionRepository taskProductionRepository,
    ITaskDetailRepository taskDetailRepository,
    IProductMaterialRepository productMaterialRepository,
    IProcessProductRepository processProductRepository,
    IDashboardRepository dashboardRepository
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<ProductionTaskCommand, MResponse<bool>>
    {
        public async Task<MResponse<bool>> Handle(ProductionTaskCommand request, CancellationToken cancellationToken)
        {
            MResponse<bool> result = new();

            List<TaskDetailEntity> taskDetailEntities = [];

            List<ProductMaterialEntity> taskMaterialEntities = [];

            List<ProductProcessEntity> taskProcessEntities = [];

            List<DashboardEntity> dashboardEntities = [];

            List<TaskProductionEntity> taskProductionEntities = request.ProductWrappers.Select(wrapper => new TaskProductionEntity
            {
                TaskName = request.TaskName,
                EmployeeName = request.Employee,
                FactoryName = request.Factory,
                DeadlineDate = request.DeadlineDate
            }).ToList();

            _ = await taskProductionRepository.AddBatchAsync(taskProductionEntities);

            _ = await taskProductionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            foreach (TaskProductionEntity wrapper in taskProductionEntities)
            {
                dashboardEntities.Add(new DashboardEntity
                {
                    TaskId = wrapper.EntityId,
                    TaskName = request.TaskName,
                    DeadlineDate = request.DeadlineDate,
                    Employee = request.Employee,
                    Factory = request.Factory,
                    TaskType = TaskType.sx
                });
            }

            foreach ((CreateOrUpdateTaskRequest wrapper, TaskProductionEntity taskProductEntity) in request.ProductWrappers.Zip(taskProductionEntities))
            {
                Guid taskId = taskProductEntity.EntityId;

                List<TaskDetailEntity> taskDetails = MapTaskDetails(wrapper.TaskProducts, taskId, wrapper.WrapperId);

                List<ProductMaterialEntity> taskMaterials = MapTaskMaterials(wrapper.TaskMaterials, taskId, wrapper.WrapperId);

                ProductProcessEntity taskProcesses = MapTaskProcess(wrapper.TaskProcesses, taskId, wrapper.WrapperId);

                taskDetailEntities.AddRange(taskDetails);
                taskMaterialEntities.AddRange(taskMaterials);
                taskProcessEntities.Add(taskProcesses);
            }

            await taskProductionRepository.ExecuteTransactionAsync(async () =>
            {
                _ = await taskDetailRepository.AddBatchAsync(taskDetailEntities);
                _ = await productMaterialRepository.AddBatchAsync(taskMaterialEntities);
                _ = await processProductRepository.AddBatchAsync(taskProcessEntities);
                _ = await dashboardRepository.AddBatchAsync(dashboardEntities);

                _ = await taskDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                _ = await productMaterialRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                _ = await processProductRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                _ = await dashboardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

                return result;
            });

            result.Result = true;
            return result;
        }

        private static ProductProcessEntity MapTaskProcess(TaskProcessRequest process, Guid taskId, int wrapperId)
        {
            return new ProductProcessEntity
            {
                StepOne = process.StepOne,
                StepTwo = process.StepTwo,
                StepThree = process.StepThree,
                StepFour = process.StepFour,
                StepFive = process.StepFive,
                StepSix = process.StepSix,
                StepSeven = process.StepSeven,
                StepEight = process.StepEight,
                TaskId = taskId,
                WrapperId = wrapperId
            };
        }

        private static List<ProductMaterialEntity> MapTaskMaterials(IEnumerable<TaskMaterialRequest> materials, Guid taskId, int wrapperId)
        {
            return materials.Select(material => new ProductMaterialEntity
            {
                ProductName = material.ProductName,
                Ingredient = material.Ingredient,
                Characteristic = material.Characteristic,
                ColorCode = material.ColorCode,
                FileNumber = material.FileNumber,
                Volume = material.Volume,
                Factory = material.Factory,
                OrderNumber = material.OrderNumber,
                Note = material.Note,
                TaskId = taskId,
                Structure = material.Structure,
                WrapperId = wrapperId
            }).ToList();
        }


        private static List<TaskDetailEntity> MapTaskDetails(IEnumerable<TaskMaterialRequest> products, Guid taskId, int wrapperId)
        {
            return products.Select(product => new TaskDetailEntity
            {
                ProductName = product.ProductName,
                Ingredient = product.Ingredient,
                Characteristic = product.Characteristic,
                ColorCode = product.ColorCode,
                FileNumber = product.FileNumber,
                Volume = product.Volume,
                Price = product.Price,
                OrderNumber = product.OrderNumber,
                Note = product.Note,
                TaskId = taskId,
                Structure = product.Structure,
                WrapperId = wrapperId
            }).ToList();
        }
    }

}
