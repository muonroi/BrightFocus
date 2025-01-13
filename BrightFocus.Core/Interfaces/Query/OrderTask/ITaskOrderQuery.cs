namespace BrightFocus.Core.Interfaces.Query.OrderTask
{
    public interface ITaskOrderQuery
        : IMQueries<TaskOrderEntity>
    {
        Task<TaskResponse?> GetOrderTaskById(Guid entityId);
    }
}
