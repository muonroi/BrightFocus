



namespace BrightFocus.Application.Query.GetDashboardTask
{
    public class GetDashboardTaskCommand : IRequest<MResponse<MPagedResult<DashboardResponseModel>>>
    {
        public int PageIndex { get; set; }

    }
}
