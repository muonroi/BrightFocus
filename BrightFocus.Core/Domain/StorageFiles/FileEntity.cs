namespace BrightFocus.Core.Domain.StorageFiles
{
    public class FileEntity : MEntity
    {
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
    }
}
