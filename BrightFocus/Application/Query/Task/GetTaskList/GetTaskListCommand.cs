namespace BrightFocus.Application.Query.Task.GetTaskList
{
    public class GetTaskListCommand : IRequest<MResponse<MPagedResult<TaskListDto>>>
    {
        public int Page { get; set; }
        public string Search { get; set; } = string.Empty;
        public string SortBy { get; set; } = string.Empty;
        public string SortOrder { get; set; } = string.Empty;
    }
}
