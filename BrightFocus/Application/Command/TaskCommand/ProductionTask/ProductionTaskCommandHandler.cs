

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
        IProcessProductRepository processProductRepository
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

            foreach (CreateOrUpdateTaskRequest wrapper in request.ProductWrappers)
            {
                List<TaskDetailEntity> taskDetails = Mapper.Map<List<TaskDetailEntity>>(wrapper.TaskProducts)
                    .Select(x =>
                    {
                        x.TaskId = taskId;
                        return x;
                    }).ToList();

                List<ProductMaterialEntity> taskMaterials = Mapper.Map<List<ProductMaterialEntity>>(wrapper.TaskMaterials)
                    .Select(x =>
                    {
                        x.TaskId = taskId;
                        return x;
                    }).ToList();

                ProductProcessEntity taskProcesses = Mapper.Map<ProductProcessEntity>(wrapper.TaskProcesses);
                taskProcesses.TaskId = taskId;

                taskDetailEntities.AddRange(taskDetails);
                taskMaterialEntities.AddRange(taskMaterials);
                taskProcessEntities.Add(taskProcesses);
            }

            Task<int> detailTask = taskDetailRepository.AddBatchAsync(taskDetailEntities);
            Task<int> materialTask = productMaterialRepository.AddBatchAsync(taskMaterialEntities);
            Task<int> processTask = processProductRepository.AddBatchAsync(taskProcessEntities);

            _ = await Task.WhenAll(detailTask, materialTask, processTask);
            _ = await taskDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            result.Result = true;
            return result;
        }
    }
}
