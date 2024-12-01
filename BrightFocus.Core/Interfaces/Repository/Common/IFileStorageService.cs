namespace BrightFocus.Core.Interfaces.Repository.Common
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(IFormFile file, string folderName);
    }
}
