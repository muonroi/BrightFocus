


namespace BrightFocus.Controllers
{
    public class ExternalResourceController(IMediator mediator, Serilog.ILogger logger, IMapper mapper) : MControllerBase(mediator, logger, mapper)
    {
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            MResponse<string> result = await Mediator.Send(new UploadFileCommand { File = file });
            return Ok(result);
        }
    }
}
