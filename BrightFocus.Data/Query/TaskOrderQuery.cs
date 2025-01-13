

namespace BrightFocus.Data.Query
{
    public class TaskOrderQuery(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext) : MQuery<TaskOrderEntity>(dbContext, authContext), ITaskOrderQuery
    {
        public async Task<TaskResponse?> GetOrderTaskById(Guid entityId)
        {
            TaskOrderEntity? taskInfo = await Queryable.FirstOrDefaultAsync(x => x.EntityId == entityId);
            if (taskInfo is null)
            {
                return null;
            }
            List<OrderEntity> orderEntities = dbContext.OrderEntities.Where(x => x.TaskId == entityId && !x.IsDeleted)?.ToList() ?? [];

            List<OrderExportEntity> exportOrderEntities = dbContext.ExportOrderEntities.Where(x => x.TaskId == entityId && !x.IsDeleted)?.ToList() ?? [];

            TaskResponse result = new()
            {
                OrderTaskResponse = new TaskOrderResponse()
                {
                    EntityId = entityId,
                    TaskName = taskInfo.TaskName,
                    Employee = taskInfo.EmployeeName,
                    CustomerCode = taskInfo.CustomerCode,
                    CustomerName = taskInfo.CustomerName,
                    DeadlineDate = taskInfo.DeadlineDate.ToString(format: "dd/MM/yyyy"),
                    Orders = orderEntities.Select(x => new TaskMaterialResponse()
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
                    ExportOrders = exportOrderEntities.Select(x => new TaskMaterialResponse()
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
