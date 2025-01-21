

namespace BrightFocus.Application.Query.GetWarehousePaging
{
    public class GetWarehousePagingCommand : IRequest<MResponse<MPagedResult<TaskMaterialResponse>>>
    {
        public int PageIndex { get; set; }
    }
}
