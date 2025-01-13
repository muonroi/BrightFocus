namespace BrightFocus.Core.Models.TaskLists.Response
{
    public class TaskOrderResponse
    {
        public Guid EntityId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Employee { get; set; } = string.Empty;
        public string DeadlineDate { get; set; } = string.Empty;
        public List<TaskMaterialResponse> Orders { get; set; } = [];
        public List<TaskMaterialResponse> ExportOrders { get; set; } = [];
    }
}
