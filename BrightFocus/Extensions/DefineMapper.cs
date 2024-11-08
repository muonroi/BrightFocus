namespace BrightFocus.Extensions
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            _ = CreateMap<CreateTaskCommand, TaskList>();
            _ = CreateMap<TaskDetail, TaskDetailInListDto>();
            _ = CreateMap<TaskDetail, TaskDetailDto>();
            _ = CreateMap<TaskList, TaskDetailInListDto>();
            _ = CreateMap<TaskList, TaskListDto>();
            _ = CreateMap<TaskDetailDto, TaskDetail>();
        }
    }
}
