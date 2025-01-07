namespace BrightFocus.Application.Command.TaskCommand.ProductionTask.Profiles
{
    public class ProductionTaskMappingProfile : Profile
    {
        public ProductionTaskMappingProfile()
        {
            // ✅ Ánh xạ `TaskMaterialRequest` -> `TaskDetailEntity`
            _ = CreateMap<TaskMaterialRequest, TaskDetailEntity>()
                .ForMember(dest => dest.TaskId, opt => opt.Ignore());

            // ✅ Ánh xạ `TaskMaterialRequest` -> `ProductMaterialEntity`
            _ = CreateMap<TaskMaterialRequest, ProductMaterialEntity>()
                .ForMember(dest => dest.TaskId, opt => opt.Ignore());

            // ✅ Ánh xạ `TaskProcessRequest` -> `ProductProcessEntity`
            _ = CreateMap<TaskProcessRequest, ProductProcessEntity>()
                .ForMember(dest => dest.TaskId, opt => opt.Ignore());
        }
    }
}
