

namespace BrightFocus.Core.Interfaces.Query.ProductionTask
{
    public interface ITaskProductionQuery : IMQueries<TaskProductionEntity>
    {
        Task<TaskResponse?> GetProductionTaskById(Guid entityId);
    }
}
