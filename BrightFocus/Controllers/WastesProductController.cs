

namespace BrightFocus.Controllers
{
    [Route("WastesProducts")]
    [ApiVersion("1.0")]
    public class WastesProductController(IMediator mediator, Serilog.ILogger logger
        , IMapper mapper
        , IUnitOfWork unitOfWork) : MControllerBase(mediator, logger)
    {
        [HttpGet]
        public async Task<IActionResult> GetWastesProductById([FromQuery] Guid id)
        {
            MResponse<WastesInListDto> response = new();
            WastesProduct? wastes = await unitOfWork.WastesRepository.GetByGuidAsync(id);
            if (wastes == null)
            {
                return NotFound();
            }
            WastesInListDto result = mapper.Map<WastesProduct, WastesInListDto>(wastes);
            response.Result = result;
            return Ok(response);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetWastesProductListPaging([FromQuery] string keyword, int pageIndex, int pageSize)
        {
            MResponse<MPagedResult<WastesInListDto>> result = await unitOfWork.WastesRepository.GetWastesListPagingAsync(pageIndex, pageSize, keyword);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWastesProduct([FromBody] CreateOrUpdateWastesRequest request)
        {
            WastesProduct wastes = mapper.Map<CreateOrUpdateWastesRequest, WastesProduct>(request);

            _ = unitOfWork.WastesRepository.Add(wastes);

            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWastesProduct(Guid id, [FromBody] CreateOrUpdateWastesRequest request)
        {
            WastesProduct? wastes = await unitOfWork.WastesRepository.GetByGuidAsync(id);
            if (wastes == null)
            {
                return NotFound();
            }
            _ = mapper.Map(request, wastes);

            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWastesProduct([FromQuery] Guid[] ids)
        {
            foreach (Guid id in ids)
            {
                WastesProduct? wastes = await unitOfWork.WastesRepository.GetByGuidAsync(id);
                if (wastes == null)
                {
                    return NotFound();
                }
                _ = await unitOfWork.WastesRepository.DeleteAsync(wastes);
            }
            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }
    }
}
