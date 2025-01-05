namespace BrightFocus.Core.Models.TaskLists.Request.Regulars
{
    public class TaskMaterialRequest
    {
        public string ProductName { get; set; } = string.Empty;

        public string Material { get; set; } = string.Empty;

        public string Ingredient { get; set; } = string.Empty;

        public string Characteristic { get; set; } = string.Empty;

        public string ColorCode { get; set; } = string.Empty;

        public string FileNumber { get; set; } = string.Empty;

        public double Volume { get; set; }

        public string Warehouse { get; set; } = string.Empty;

        public string OrderNumber { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;
    }
}
