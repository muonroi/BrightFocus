namespace BrightFocus.Application.Command.TaskCommand.OrderTask
{
    public class OrderTaskCommand : IRequest<MResponse<bool>>
    {
        public Guid? EntityId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Employee { get; set; } = string.Empty;
        public string Factory { get; set; } = string.Empty;
        public DateTime DeadlineDate { get; set; }
        public List<TaskMaterialRequest> Orders { get; set; } = [];
        public List<TaskMaterialRequest> ExportOrders { get; set; } = [];
    }
}
