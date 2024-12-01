







namespace BrightFocus.Data.Repository.Common
{
    public class FileStorageService(IWebHostEnvironment webHostEnvironment) : IFileStorageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public async Task<string> SaveFileAsync(IFormFile file, string folderName)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderName);
            _ = Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            await using FileStream fileStream = new(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return Path.Combine(folderName, uniqueFileName);
        }
    }
}
