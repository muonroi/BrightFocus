namespace BrightFocus.Core.Models.TaskLists.Request.ProductionTask
{
    public class TaskProcessRequest : IMapFrom<ProductProcessEntity>
    {
        public string ProductOne { get; set; } = string.Empty;
        public string ProductTwo { get; set; } = string.Empty;
        public string ProductThree { get; set; } = string.Empty;
        public string ProductFour { get; set; } = string.Empty;
        public string ProductFive { get; set; } = string.Empty;
        public string ProductSix { get; set; } = string.Empty;
        public string ProductSeven { get; set; } = string.Empty;
        public string ProductEight { get; set; } = string.Empty;
    }
}
