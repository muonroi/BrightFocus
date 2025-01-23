namespace BrightFocus.Application.Command.Task.ImportExportTask
{
    public class ImportExportTaskCommand : IRequest<MResponse<bool>>
    {
        public Guid? EntityId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public SourceImport Source { get; set; }
        public string Employee { get; set; } = string.Empty;
        public string Factory { get; set; } = string.Empty;
        public DateTime DeadlineDate { get; set; }
        public List<TaskMaterialRequest> ProductsImport { get; set; } = [];
        public List<TaskMaterialRequest>? ProductsExport { get; set; } = [];

    }
}
