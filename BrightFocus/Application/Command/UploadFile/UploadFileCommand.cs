namespace BrightFocus.Application.Command.UploadFile
{
    public class UploadFileCommand : IRequest<MResponse<string>>
    {
        public required IFormFile File { get; set; }
    }
}
