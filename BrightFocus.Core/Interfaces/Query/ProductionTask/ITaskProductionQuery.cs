

namespace BrightFocus.Core.Interfaces.Query.ProductionTask
{
    public interface ITaskProductionQuery : IMQueries<TaskProductionEntity>
    {
        Task<ProductionTaskResponse?> GetProductionTaskById(Guid entityId);
    }
}
