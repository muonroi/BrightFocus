

namespace BrightFocus.Core.Models.TaskLists.Request;

public class CreateOrUpdateTaskRequest : IMapFrom<TaskListEntity>
{
    public Guid? EntityId { get; set; }

    public string TaskName { get; set; } = string.Empty;

    public string Employee { get; set; } = string.Empty;

    public string? Customer { get; set; } = string.Empty;

    public DateTime DeadlineDate { get; set; }

    public string? Note { get; set; } = string.Empty;

    public string Process { get; set; } = string.Empty;

    public IFormFile? File { get; set; }
    public string? TaskDetails { get; set; } = string.Empty;

    public TaskType TaskType { get; set; } = TaskType.Red;
}
