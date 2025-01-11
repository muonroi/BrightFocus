namespace BrightFocus.Data.Query
{
    public class DashboardQuery(BrightFocusDbContext dbContext,
        MAuthenticateInfoContext authContext) : MQuery<DashboardEntity>(dbContext, authContext), IDashboardQuery
    {
        public async Task<MPagedResult<DashboardResponseModel>> GetDashboardData(int pageIndex, int pageSize)
        {
            IOrderedQueryable<DashboardEntity> query = Queryable.OrderBy(x => x.TaskName);
            MPagedResult<DashboardResponseModel> response = await GetPagedAsync(query, pageIndex, pageSize,
              x => new DashboardResponseModel
              {
                  EntityId = x.EntityId,
                  TaskName = x.TaskName,
                  ProductName = x.ProductName,
                  Material = x.Material,
                  Volume = x.Volume,
                  DeadlineDate = x.DeadlineDate,
                  Employee = x.Employee,
                  Factory = x.Factory,
                  TaskId = x.TaskId
              });
            return response;
        }
    }
}
