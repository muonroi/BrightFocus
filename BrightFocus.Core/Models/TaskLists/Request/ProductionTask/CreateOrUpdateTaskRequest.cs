

namespace BrightFocus.Core.Models.TaskLists.Request.ProductionTask;

public class CreateOrUpdateTaskRequest
{
    public int WrapperId { get; set; }

    public List<TaskMaterialRequest> TaskProducts { get; set; } = [];

    public List<TaskMaterialRequest> TaskMaterials { get; set; } = [];

    public TaskProcessRequest TaskProcesses { get; set; } = new();
}
