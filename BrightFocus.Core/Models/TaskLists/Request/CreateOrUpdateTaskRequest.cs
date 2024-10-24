

namespace BrightFocus.Core.Models.TaskLists.Request
{
    public class CreateOrUpdateTaskRequest
    {
        public string Name { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateTime DeadlineDate { get; set; }

        public string Note { get; set; } = string.Empty;

        public TaskType TaskType { get; set; }

        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                _ = CreateMap<CreateOrUpdateTaskRequest, TaskList>();
            }
        }
    }
}
