

namespace BrightFocus.Core.Models.TaskLists.Models
{
    public class TaskInListDto : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime DeadlineDate { get; set; }

        public string Note { get; set; } = string.Empty;

        public TaskType TaskType { get; set; }

        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                _ = CreateMap<TaskList, TaskInListDto>();
                _ = CreateMap<TaskList, TaskListDto>();
            }
        }
    }
}
