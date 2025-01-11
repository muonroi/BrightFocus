


namespace BrightFocus.Application.Command.TaskCommand.OrderTask
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

            List<OrderEntity> orders = [];
            List<OrderExportEntity> orderExports = [];
            List<DashboardEntity> dashboardEntities = [];

            foreach (TaskMaterialRequest order in request.Orders)
            {
                OrderEntity orderData = Mapper.Map<OrderEntity>(order);
                orderData.TaskId = taskId;
                orders.Add(orderData);

                DashboardEntity dashboard = new()
                {
                    TaskId = taskId,
                    TaskName = request.TaskName,
                    ProductName = order.ProductName,
                    Material = order.Material,
                    Volume = order.Volume.ToString(),
                    DeadlineDate = request.DeadlineDate,
                    Employee = request.Employee,
                    Factory = request.Factory
                };
                dashboardEntities.Add(dashboard);
            }

            foreach (TaskMaterialRequest orderExport in request.ExportOrders)
            {
                OrderExportEntity orderExportData = Mapper.Map<OrderExportEntity>(orderExport);
                orderExportData.TaskId = taskId;
                orderExports.Add(orderExportData);


                DashboardEntity dashboard = new()
                {
                    TaskId = taskId,
                    TaskName = request.TaskName,
                    ProductName = orderExport.ProductName,
                    Material = orderExport.Material,
                    Volume = orderExport.Volume.ToString(),
                    DeadlineDate = request.DeadlineDate,
                    Employee = request.Employee,
                    Factory = request.Factory
                };
                dashboardEntities.Add(dashboard);
            }


            Task<int> dashboardTask = dashboardRepository.AddBatchAsync(dashboardEntities);

            Task<int> importProductTask = orderRepository.AddBatchAsync(orders);

            Task<int> exportProductTask = orderExportRepository.AddBatchAsync(orderExports);

            _ = await Task.WhenAll(importProductTask, exportProductTask, dashboardTask);

            _ = await dashboardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            _ = await orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            _ = await orderExportRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            result.Result = true;

            return result;
        }
    }
}