namespace BrightFocus.Core.Models.TaskLists.Response
{
    public class TaskProcessResponse
    {
        public string StepOne { get; set; } = string.Empty;
        public string StepTwo { get; set; } = string.Empty;
        public string StepThree { get; set; } = string.Empty;
        public string StepFour { get; set; } = string.Empty;
        public string StepFive { get; set; } = string.Empty;
        public string StepSix { get; set; } = string.Empty;
        public string StepSeven { get; set; } = string.Empty;
        public string StepEight { get; set; } = string.Empty;

        public Guid TaskId { get; set; }

        public int WrapperId { get; set; }
    }
}
