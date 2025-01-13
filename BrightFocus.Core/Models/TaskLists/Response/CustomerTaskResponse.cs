namespace BrightFocus.Core.Models.TaskLists.Response
{
    public class CustomerTaskResponse
    {
        public Guid? EntityId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}
