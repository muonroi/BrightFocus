

namespace BrightFocus.Core.Models.TaskLists.Request.ProductionTask;

public class CreateOrUpdateTaskRequest : IMapFrom<TaskProductionEntity>
{
    public Guid? EntityId { get; set; }

    public string TaskName { get; set; } = string.Empty;

    public string Employee { get; set; } = string.Empty;

    public string Factory { get; set; } = string.Empty;

    public DateTime DeadlineDate { get; set; }

    public IEnumerable<TaskMaterialRequest> TaskProducts { get; set; } = [];

    public IEnumerable<TaskMaterialRequest> TaskMaterials { get; set; } = [];

    public IEnumerable<TaskProcessRequest> TaskProcesses { get; set; } = [];
}
