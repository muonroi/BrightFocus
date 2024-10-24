namespace BrightFocus.Core.Models.Base
{
    public class BaseModel
    {
        public Guid EntityId { get; set; }
        public string? CreatedUserName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
