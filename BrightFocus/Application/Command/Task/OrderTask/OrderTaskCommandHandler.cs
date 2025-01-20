namespace BrightFocus.Application.Command.Task.OrderTask
{
    public class OrderTaskCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        IOrderRepository orderRepository,
        IOrderExportRepository orderExportRepository,
        IOrderTaskRepository orderTaskRepository,
        IDashboardRepository dashboardRepository
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<OrderTaskCommand, MResponse<bool>>
    {
        public async Task<MResponse<bool>> Handle(OrderTaskCommand request, CancellationToken cancellationToken)
        {
            MResponse<bool> result = new();

            List<OrderEntity> orders = [];
            List<OrderExportEntity> orderExports = [];

            TaskOrderEntity taskOrderEntity = new()
            {
                TaskName = request.TaskName,
                CustomerCode = request.CustomerCode,
                CustomerName = request.CustomerName,
                EmployeeName = request.Employee,
                DeadlineDate = request.DeadlineDate,
            };

            _ = orderTaskRepository.Add(taskOrderEntity);
            _ = await orderTaskRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            Guid taskId = taskOrderEntity.EntityId;

            foreach (TaskMaterialRequest order in request.Orders)
            {
                OrderEntity orderEntity = MapOrderEntity(order, taskId);
                orders.Add(orderEntity);
            }

            foreach (TaskMaterialRequest orderExport in request.ExportOrders)
            {
                OrderExportEntity orderExportEntity = MapOrderExportEntity(orderExport, taskId);
                orderExports.Add(orderExportEntity);
            }

            DashboardEntity dashboard = new()
            {
                TaskId = taskId,
                TaskName = request.TaskName,
                DeadlineDate = request.DeadlineDate,
                Employee = request.Employee,
                TaskType = TaskType.dh
            };

            await orderTaskRepository.ExecuteTransactionAsync(async () =>
            {
                _ = await orderRepository.AddBatchAsync(orders);
                _ = await orderExportRepository.AddBatchAsync(orderExports);
                _ = dashboardRepository.Add(dashboard);

                _ = await orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                _ = await orderExportRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                _ = await dashboardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

                return result;
            });

            result.Result = true;
            return result;
        }

        private static OrderEntity MapOrderEntity(TaskMaterialRequest order, Guid taskId)
        {
            return new OrderEntity
            {
                ProductName = order.ProductName,
                Ingredient = order.Ingredient,
                Characteristic = order.Characteristic,
                ColorCode = order.ColorCode,
                FileNumber = order.FileNumber,
                Volume = order.Volume,
                Warehouse = order.Warehouse,
                OrderNumber = order.OrderNumber,
                Note = order.Note,
                TaskId = taskId,
                Structure = order.Structure
            };
        }

        private static OrderExportEntity MapOrderExportEntity(TaskMaterialRequest orderExport, Guid taskId)
        {
            return new OrderExportEntity
            {
                ProductName = orderExport.ProductName,
                Ingredient = orderExport.Ingredient,
                Characteristic = orderExport.Characteristic,
                ColorCode = orderExport.ColorCode,
                FileNumber = orderExport.FileNumber,
                Volume = orderExport.Volume,
                Warehouse = orderExport.Warehouse,
                OrderNumber = orderExport.OrderNumber,
                Note = orderExport.Note,
                TaskId = taskId,
                Structure = orderExport.Structure
            };
        }
    }
}
