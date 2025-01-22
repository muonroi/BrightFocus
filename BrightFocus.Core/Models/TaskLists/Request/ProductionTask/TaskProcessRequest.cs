namespace BrightFocus.Core.Models.TaskLists.Request.ProductionTask
{
    public class TaskProcessRequest : IMapFrom<ProductProcessEntity>
    {
        public string StepOne { get; set; } = string.Empty;
        public string StepTwo { get; set; } = string.Empty;
        public string StepThree { get; set; } = string.Empty;
        public string StepFour { get; set; } = string.Empty;
        public string StepFive { get; set; } = string.Empty;
        public string StepSix { get; set; } = string.Empty;
        public string StepSeven { get; set; } = string.Empty;
        public string StepEight { get; set; } = string.Empty;
    }
}
