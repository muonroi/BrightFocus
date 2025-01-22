namespace BrightFocus.Application.Query.GetOrderByCode
{
    public class GetOrderByCodeCommand : IRequest<MResponse<IEnumerable<TaskMaterialResponse>>>
    {
        public string OrderNo { get; set; } = string.Empty;
    }
}
