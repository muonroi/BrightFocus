namespace BrightFocus.Data.Query
{
    public class DashboardQuery(BrightFocusDbContext dbContext,
        MAuthenticateInfoContext authContext) : MQuery<DashboardEntity>(dbContext, authContext), IDashboardQuery
    {
        public async Task<MPagedResult<DashboardResponseModel>> GetDashboardData(int pageIndex, int pageSize)
        {
            IOrderedQueryable<DashboardEntity> query = Queryable.OrderBy(x => x.TaskName);

            List<DashboardResponseModel> rawData = await query
                .Select(x => new DashboardResponseModel
                {
                    EntityId = x.EntityId,
                    TaskName = x.TaskName,
                    ProductName = x.ProductName,
                    Material = x.Characteristic,
                    Volume = x.Volume,
                    DeadlineDate = x.DeadlineDate.ToString("dd/MM/yyyy"),
                    Employee = x.Employee,
                    Factory = x.Factory,
                    TaskId = x.TaskId,
                    TaskType = x.TaskType

                })
                .ToListAsync();

            List<DashboardResponseModel> groupedTasks = rawData
                .GroupBy(x => new { x.DeadlineDate, x.Employee, x.Factory })
                .Select(group =>
                {
                    List<DashboardResponseModel> taskList = [.. group];
                    DashboardResponseModel parentTask = taskList.First();

                    parentTask.ExpandTask = taskList
                        .Where(x => x.TaskId != parentTask.TaskId)
                        .ToList();

                    return parentTask;
                })
                .ToList();

            int totalRowCount = groupedTasks.Count;

            List<DashboardResponseModel> pagedItems = groupedTasks
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new MPagedResult<DashboardResponseModel>
            {
                Items = pagedItems,
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = totalRowCount
            };
        }
    }
}
