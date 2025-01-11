namespace BrightFocus.Application.Command.TaskCommand.ProductionTask
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

            TaskProductionEntity taskProductEntity = new()
            {
                TaskName = request.TaskName,
                EmployeeName = request.Employee,
                FactoryName = request.Factory,
                DeadlineDate = request.DeadlineDate,
            };

            _ = taskProductionRepository.Add(taskProductEntity);
            _ = await taskProductionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            Guid taskId = taskProductEntity.EntityId;

            List<TaskDetailEntity> taskDetailEntities = [];
            List<ProductMaterialEntity> taskMaterialEntities = [];
            List<ProductProcessEntity> taskProcessEntities = [];
            List<DashboardEntity> dashboardEntities = [];

            foreach (CreateOrUpdateTaskRequest wrapper in request.ProductWrappers)
            {
                List<TaskDetailEntity> taskDetails = Mapper.Map<List<TaskDetailEntity>>(wrapper.TaskProducts)
                    .Select(x =>
                    {
                        x.TaskId = taskId;
                        x.WrapperId = wrapper.WrapperId;
                        return x;
                    }).ToList();

                List<ProductMaterialEntity> taskMaterials = Mapper.Map<List<ProductMaterialEntity>>(wrapper.TaskMaterials)
                    .Select(x =>
                    {
                        x.TaskId = taskId;
                        x.WrapperId = wrapper.WrapperId;
                        return x;
                    }).ToList();

                ProductProcessEntity taskProcesses = Mapper.Map<ProductProcessEntity>(wrapper.TaskProcesses);
                taskProcesses.TaskId = taskId;
                taskProcesses.WrapperId = wrapper.WrapperId;

                foreach (TaskMaterialRequest product in wrapper.TaskProducts)
                {
                    DashboardEntity dashboard = new()
                    {
                        TaskId = taskId,
                        TaskName = request.TaskName,
                        ProductName = product.ProductName,
                        Material = product.Material,
                        Volume = product.Volume.ToString(),
                        DeadlineDate = request.DeadlineDate,
                        Employee = request.Employee,
                        Factory = request.Factory
                    };
                    dashboardEntities.Add(dashboard);
                }

                taskDetailEntities.AddRange(taskDetails);
                taskMaterialEntities.AddRange(taskMaterials);
                taskProcessEntities.Add(taskProcesses);

            }


            Task<int> detailTask = taskDetailRepository.AddBatchAsync(taskDetailEntities);
            Task<int> materialTask = productMaterialRepository.AddBatchAsync(taskMaterialEntities);
            Task<int> processTask = processProductRepository.AddBatchAsync(taskProcessEntities);
            Task<int> dashboardTask = dashboardRepository.AddBatchAsync(dashboardEntities);

            _ = await Task.WhenAll(detailTask, materialTask, processTask, dashboardTask);
            _ = await taskDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            _ = await productMaterialRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            _ = await processProductRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            _ = await dashboardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            result.Result = true;
            return result;
        }
    }
}
