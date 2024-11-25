











namespace BrightFocus.Application.Command.TaskCommand.CreateTask;

public class CreateTaskCommandHandler(IMapper mapper, MAuthenticateInfoContext tokenInfo, IAuthenticateRepository authenticateRepository, Serilog.ILogger logger, IMediator mediator, MPaginationConfig paginationConfig,
    ITaskListRepository taskListRepository,
    ITaskDetailRepository taskDetailRepository,
    IDeliveryWarehouseRepository deliveryWarehouseRepository,
    IWebHostEnvironment webHostEnvironment
    ) :
    BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<CreateTaskCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();

        TaskListEntity taskEntity = Mapper.Map<CreateTaskCommand, TaskListEntity>(request);
        if (!taskEntity.IsValid())
        {
            result.StatusCode = StatusCodes.Status400BadRequest;
            result.AddResultFromErrorList(taskEntity.ErrorMessages);
            return result;
        }

        if (request.File != null)
        {
            string savedFilePath = await SaveFileAsync(request.File);
            if (!string.IsNullOrEmpty(savedFilePath))
            {
                taskEntity.FileUrl = savedFilePath;
            }
        }

        await taskListRepository.ExecuteTransactionAsync(async () =>
        {
            _ = taskListRepository.Add(taskEntity);

            if (request.TaskDetails != null)
            {
                await ProcessTaskDetailsAndDeliveryWarehouses(request, taskEntity.EntityId);
            }

            await SaveAllChangesAsync();

            result.Result = true;
            return result;
        });

        return result;
    }

    private async Task<string> SaveFileAsync(IFormFile file)
    {
        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");

        if (!Directory.Exists(uploadsFolder))
        {
            _ = Directory.CreateDirectory(uploadsFolder);
        }

        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);

        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (FileStream fileStream = new(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return Path.Combine("uploads", uniqueFileName);
    }

    private async Task ProcessTaskDetailsAndDeliveryWarehouses(CreateTaskCommand request, Guid taskId)
    {
        List<TaskDetailEntity> taskDetails = request.TaskDetails.Select(taskDetail =>
        {
            TaskDetailEntity taskDetailEntity = Mapper.Map<TaskDetailDto, TaskDetailEntity>(taskDetail);
            taskDetailEntity.TaskId = taskId;
            return taskDetailEntity;
        }).ToList();

        _ = await taskDetailRepository.AddBatchAsync(taskDetails);

        List<(string FromWarehouse, string ToWarehouse)> warehousePairs = DeliveryWarehouseDto.GetWarehousePairs(request.TaskDetails);

        List<DeliveryWarehouseDto> deliveryWarehouses = GenerateDeliveryWarehousesForPair(request.TaskDetails, taskId, request.Warehouse).ToList();

        List<DeliveryWarehouseEntity> deliveryWarehouseEntities = deliveryWarehouses
            .Select(Mapper.Map<DeliveryWarehouseDto, DeliveryWarehouseEntity>)
            .ToList();

        _ = await deliveryWarehouseRepository.AddBatchAsync(deliveryWarehouseEntities);

    }

    private static IEnumerable<DeliveryWarehouseDto> GenerateDeliveryWarehousesForPair(
    IEnumerable<TaskDetailDto> taskDetails, Guid taskId, string toWarehouse)
    {
        List<TaskDetailDto> taskDetailsList = taskDetails.ToList();

        if (taskDetailsList.Count == 0)
        {
            return [];
        }

        IEnumerable<string> fromWarehouses = taskDetailsList.Skip(1).Select(td => td.Warehouse).Distinct();

        List<DeliveryWarehouseDto> deliveryWarehouseDtos = fromWarehouses
            .SelectMany(fromWarehouse => taskDetailsList
                .Where(td => td.Warehouse == fromWarehouse)
                .GroupBy(td => new { td.ProductName, td.Material, td.Employee })
                .Select(group => new DeliveryWarehouseDto
                {
                    FromWarehouse = fromWarehouse,
                    ToWarehouse = toWarehouse,
                    ProductCode = group.Key.Material,
                    ProductName = group.Key.ProductName,
                    Quantity = group.Sum(td => td.Quantity),
                    Employee = group.Key.Employee,
                    DeliveryType = DeliveryType.Waiting,
                    TaskId = taskId
                }))
            .ToList();

        IEnumerable<DeliveryWarehouseDto> distinctDeliveryWarehouses = deliveryWarehouseDtos
            .GroupBy(dw => new
            {
                dw.FromWarehouse,
                dw.ToWarehouse,
                dw.ProductCode,
                dw.Employee
            })
            .Select(group => new DeliveryWarehouseDto
            {
                FromWarehouse = group.Key.FromWarehouse,
                ToWarehouse = group.Key.ToWarehouse,
                ProductCode = group.Key.ProductCode,
                ProductName = group.First().ProductName,
                Quantity = group.Sum(dw => dw.Quantity),
                Employee = group.Key.Employee,
                DeliveryType = DeliveryType.Waiting,
                TaskId = taskId
            });

        return distinctDeliveryWarehouses;
    }



    private async Task SaveAllChangesAsync()
    {
        _ = await taskDetailRepository.UnitOfWork.SaveChangesAsync();
        _ = await deliveryWarehouseRepository.UnitOfWork.SaveChangesAsync();
        _ = await taskListRepository.UnitOfWork.SaveChangesAsync();
    }
}
