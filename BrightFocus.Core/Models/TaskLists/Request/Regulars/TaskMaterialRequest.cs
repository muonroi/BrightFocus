namespace BrightFocus.Core.Models.TaskLists.Request.Regulars
{
    public class TaskMaterialRequest : IMapFrom<ProductMaterialEntity>
    {
        public string ProductName { get; set; } = string.Empty;

        public string Ingredient { get; set; } = string.Empty;

        public string Characteristic { get; set; } = string.Empty;

        public string ColorCode { get; set; } = string.Empty;

        public string FileNumber { get; set; } = string.Empty;

        public double Volume { get; set; }

        public double Price { get; set; }

        public string Factory { get; set; } = string.Empty;

        public string OrderNumber { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public string Structure { get; set; } = string.Empty;

    }
}
