namespace BrightFocus.Core.Models.TaskLists.Response
{
    public class TaskMaterialResponse
    {
        public Guid? EntityId { get; set; }
        public string ProductName { get; set; } = string.Empty;

        public string Material { get; set; } = string.Empty;

        public string Ingredient { get; set; } = string.Empty;

        public string Characteristic { get; set; } = string.Empty;

        public string ColorCode { get; set; } = string.Empty;

        public string FileNumber { get; set; } = string.Empty;

        public double Volume { get; set; }

        public double Price { get; set; }

        public double TotalAmount { get; set; }

        public string Factory { get; set; } = string.Empty;

        public string OrderNumber { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;
        public string Structure { get; set; } = string.Empty;
        public int WrapperId { get; set; }

        public string CreatedDate { get; set; } = string.Empty;

        public IEnumerable<TaskMaterialResponse>? Details { get; set; }
    }
}
