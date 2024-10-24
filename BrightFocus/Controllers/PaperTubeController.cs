

namespace BrightFocus.Controllers
{
    [Route("PaperTubes")]
    [ApiVersion("1.0")]
    public class PaperTubeController(IMediator mediator, Serilog.ILogger logger
        , IMapper mapper
        , IUnitOfWork unitOfWork) : MControllerBase(mediator, logger)
    {
        [HttpGet]
        public async Task<IActionResult> GetPaperTubeById([FromQuery] Guid id)
        {
            MResponse<PaperTubeInListDto> response = new();
            PaperTube? paperTube = await unitOfWork.PaperTubeRepository.GetByGuidAsync(id);
            if (paperTube == null)
            {
                return NotFound();
            }
            PaperTubeInListDto result = mapper.Map<PaperTube, PaperTubeInListDto>(paperTube);
            response.Result = result;
            return Ok(response);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetPaperTubeListPaging([FromQuery] string keyword, int pageIndex, int pageSize)
        {
            MResponse<MPagedResult<PaperTubeInListDto>> result = await unitOfWork.PaperTubeRepository.GetPaperTubeListPagingAsync(pageIndex, pageSize, keyword);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaperTube([FromBody] CreateOrUpdatePaperTubeRequest request)
        {
            PaperTube paperTube = mapper.Map<CreateOrUpdatePaperTubeRequest, PaperTube>(request);

            _ = unitOfWork.PaperTubeRepository.Add(paperTube);

            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaperTube(Guid id, [FromBody] CreateOrUpdatePaperTubeRequest request)
        {
            PaperTube? paperTube = await unitOfWork.PaperTubeRepository.GetByGuidAsync(id);
            if (paperTube == null)
            {
                return NotFound();
            }
            _ = mapper.Map(request, paperTube);

            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePaperTube([FromQuery] Guid[] ids)
        {
            foreach (Guid id in ids)
            {
                PaperTube? paperTube = await unitOfWork.PaperTubeRepository.GetByGuidAsync(id);
                if (paperTube == null)
                {
                    return NotFound();
                }
                _ = await unitOfWork.PaperTubeRepository.DeleteAsync(paperTube);
            }
            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }
    }
}
