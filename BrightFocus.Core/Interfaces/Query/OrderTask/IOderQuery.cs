namespace BrightFocus.Core.Interfaces.Query.OrderTask
{
    public interface IOderQuery : IMQueries<OrderEntity>
    {
        Task<IEnumerable<TaskMaterialResponse>> GetOrderByCode(string code);
    }
}
