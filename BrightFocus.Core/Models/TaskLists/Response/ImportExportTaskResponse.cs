namespace BrightFocus.Core.Models.TaskLists.Response
{
    public class ImportExportTaskResponse
    {
        public Guid EntityId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string Ingredient { get; set; } = string.Empty;
        public SourceImport Source { get; set; }
        public string Employee { get; set; } = string.Empty;
        public required string Factory { get; set; }
        public string DeadlineDate { get; set; } = string.Empty;
        public List<TaskMaterialResponse> ProductsImport { get; set; } = [];
        public List<TaskMaterialResponse> ProductsExport { get; set; } = [];
    }
}
