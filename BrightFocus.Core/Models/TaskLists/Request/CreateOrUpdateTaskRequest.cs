namespace BrightFocus.Core.Models.TaskLists.Request;

public class CreateOrUpdateTaskRequest : IMapFrom<TaskListEntity>
{
    public Guid? EntityId { get; set; }

    public string TaskName { get; set; } = string.Empty;

    public string ProductName { get; set; } = string.Empty;

    public string Material { get; set; } = string.Empty;

    public double Size { get; set; }

    public double Weight { get; set; }

    public string Color { get; set; } = string.Empty;

    public string Employee { get; set; } = string.Empty;

    public string FactoryName { get; set; } = string.Empty;

    public string Warehouse { get; set; } = string.Empty;

    public DateTime DeadlineDate { get; set; }

    public string? Note { get; set; } = string.Empty;

    public IEnumerable<TaskDetailDto> TaskDetails { get; set; } = [];

    public string? FileUrl { get; set; } = string.Empty;
}
