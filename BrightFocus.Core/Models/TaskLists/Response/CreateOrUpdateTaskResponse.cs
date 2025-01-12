namespace BrightFocus.Core.Models.TaskLists.Response
{
    public class CreateOrUpdateTaskResponse
    {
        public List<TaskMaterialResponse> TaskProducts { get; set; } = [];

        public List<TaskMaterialResponse> TaskMaterials { get; set; } = [];

        public List<TaskProcessResponse> TaskProcesses { get; set; } = [];
    }
}
