

namespace BrightFocus.Controllers
{
    [Route("Fibers")]
    [ApiVersion("1.0")]
    public class FiberController(IMediator mediator, Serilog.ILogger logger
        , IMapper mapper
        , IUnitOfWork unitOfWork) : MControllerBase(mediator, logger)
    {
        [HttpGet]
        public async Task<IActionResult> GetFiberById([FromQuery] Guid id)
        {
            MResponse<FibersInListDto> response = new();
            Fiber? fiber = await unitOfWork.FibersRepository.GetByGuidAsync(id);
            if (fiber == null)
            {
                return NotFound();
            }
            FibersInListDto result = mapper.Map<Fiber, FibersInListDto>(fiber);
            response.Result = result;
            return Ok(response);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetFiberListPaging([FromQuery] string keyword, int pageIndex, int pageSize)
        {
            MResponse<MPagedResult<FibersInListDto>> result = await unitOfWork.FibersRepository.GetFiberListPagingAsync(pageIndex, pageSize, keyword);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFiber([FromBody] CreateOrUpdateFiberRequest request)
        {
            Fiber fiber = mapper.Map<CreateOrUpdateFiberRequest, Fiber>(request);

            _ = unitOfWork.FibersRepository.Add(fiber);

            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFiber(Guid id, [FromBody] CreateOrUpdateFiberRequest request)
        {
            Fiber? fiber = await unitOfWork.FibersRepository.GetByGuidAsync(id);
            if (fiber == null)
            {
                return NotFound();
            }
            _ = mapper.Map(request, fiber);

            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFiber([FromQuery] Guid[] ids)
        {
            foreach (Guid id in ids)
            {
                Fiber? fiber = await unitOfWork.FibersRepository.GetByGuidAsync(id);
                if (fiber == null)
                {
                    return NotFound();
                }
                _ = await unitOfWork.FibersRepository.DeleteAsync(fiber);
            }
            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }
    }
}
