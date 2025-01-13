namespace BrightFocus.Core.Models.TaskLists.Response
{
    public class TaskResponse
    {
        public ProductionTaskResponse? ProductionTask { get; set; }

        public ImportExportTaskResponse? ImportExportTask { get; set; }

        public CustomerTaskResponse? CustomerTask { get; set; }

        public TaskOrderResponse? OrderTaskResponse { get; set; }
    }
}
