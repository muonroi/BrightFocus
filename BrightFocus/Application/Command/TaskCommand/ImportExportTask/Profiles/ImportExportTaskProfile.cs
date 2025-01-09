namespace BrightFocus.Application.Command.TaskCommand.ImportExportTask.Profiles
{
    public class ImportExportTaskProfile : Profile
    {
        public ImportExportTaskProfile()
        {
            _ = CreateMap<TaskMaterialRequest, ImportEntity>()
              .ForMember(destination => destination.TaskId, opt => opt.Ignore());

            _ = CreateMap<TaskMaterialRequest, ExportEntity>()
                .ForMember(destination => destination.TaskId, opt => opt.Ignore());

        }
    }
}
