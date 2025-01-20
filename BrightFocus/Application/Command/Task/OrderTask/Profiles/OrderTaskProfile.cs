namespace BrightFocus.Application.Command.Task.OrderTask.Profiles
{
    public class OrderTaskProfile : Profile
    {
        public OrderTaskProfile()
        {
            _ = CreateMap<TaskMaterialRequest, OrderEntity>()
                .ForMember(destination => destination.TaskId, opt => opt.Ignore());
            _ = CreateMap<TaskMaterialRequest, OrderExportEntity>()
                .ForMember(destination => destination.TaskId, opt => opt.Ignore());
        }
    }
}
