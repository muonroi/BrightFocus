namespace BrightFocus.Application.Command.TaskCommand.ProductionTask.Profiles
{
    public class ProductionTaskMappingProfile : Profile
    {
        public ProductionTaskMappingProfile()
        {
            _ = CreateMap<TaskMaterialRequest, TaskDetailEntity>()
                .ForMember(destination => destination.TaskId, opt => opt.Ignore());

            _ = CreateMap<TaskMaterialRequest, ProductMaterialEntity>()
                .ForMember(destination => destination.TaskId, opt => opt.Ignore());

            _ = CreateMap<TaskProcessRequest, ProductProcessEntity>()
                .ForMember(destination => destination.TaskId, opt => opt.Ignore());
        }
    }
}
