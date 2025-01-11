



namespace BrightFocus.Core.Interfaces.Query.Dashboard
{
    public interface IDashboardQuery : IMQueries<DashboardEntity>
    {
        //Get dashboard data
        Task<MPagedResult<DashboardResponseModel>> GetDashboardData(int pageIndex, int pageSize);
    }
}
