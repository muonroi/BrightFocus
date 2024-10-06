

namespace BrightFocus.Core.Models.TaskLists.Models
{
    public class TaskInListDto
    {
        public Guid EntityId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public int Quatity { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime DeadlineDate { get; set; }

        public DateTime CreateDateTS { get; set; }

        public string Note { get; set; } = string.Empty;

        public TaskType TaskType { get; set; }

        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<TaskList, TaskInListDto>().ForMember(dest => dest.CreateDateTS, opt => opt.MapFrom(src => src.CreatedDateTS.TimeStampToDateTime()));
                CreateMap<TaskList, TaskListDto>().ForMember(dest => dest.CreateDateTS, opt => opt.MapFrom(src => src.CreatedDateTS.TimeStampToDateTime()));
            }
        }
    }
}
