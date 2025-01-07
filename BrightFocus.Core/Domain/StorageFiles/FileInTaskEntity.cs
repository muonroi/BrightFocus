namespace BrightFocus.Core.Domain.StorageFiles
{
    public class FileInTaskEntity : MEntity
    {
        public Guid TaskId { get; set; }
        public Guid FileId { get; set; }
    }
}
