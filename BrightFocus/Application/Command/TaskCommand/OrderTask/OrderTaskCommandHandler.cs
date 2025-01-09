


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
        IOrderTaskRepository orderTaskRepository
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

            foreach (TaskMaterialRequest order in request.Orders)
            {
                OrderEntity orderData = Mapper.Map<OrderEntity>(order);
                orderData.TaskId = taskId;
                orders.Add(orderData);
            }

            foreach (TaskMaterialRequest orderExport in request.ExportOrders)
            {
                OrderExportEntity orderExportData = Mapper.Map<OrderExportEntity>(orderExport);
                orderExportData.TaskId = taskId;
                orderExports.Add(orderExportData);
            }

            Task<int> importProductTask = orderRepository.AddBatchAsync(orders);

            Task<int> exportProductTask = orderExportRepository.AddBatchAsync(orderExports);

            _ = await Task.WhenAll(importProductTask, exportProductTask);

            _ = await orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            _ = await orderExportRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            result.Result = true;

            return result;
        }
    }
}