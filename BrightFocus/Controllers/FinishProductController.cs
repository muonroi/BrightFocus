



namespace BrightFocus.Controllers
{
    [Route("FinishProducts")]
    [ApiVersion("1.0")]
    public class FinishProductController(IMediator mediator, Serilog.ILogger logger
        , IMapper mapper
        , IUnitOfWork unitOfWork) : MControllerBase(mediator, logger)
    {
        [HttpGet]
        public async Task<IActionResult> GetFinishProductById([FromQuery] Guid id)
        {
            MResponse<FinishedProductInListDto> response = new();
            FinishProduct? finishProduct = await unitOfWork.FinishedRepository.GetByGuidAsync(id);
            if (finishProduct == null)
            {
                return NotFound();
            }
            FinishedProductInListDto result = mapper.Map<FinishProduct, FinishedProductInListDto>(finishProduct);
            response.Result = result;
            return Ok(response);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetFinishProductListPaging([FromQuery] string keyword, int pageIndex, int pageSize)
        {
            MResponse<MPagedResult<FinishedProductInListDto>> result = await unitOfWork.FinishedRepository.GetFinishedListPagingAsync(pageIndex, pageSize, keyword);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFinishProduct([FromBody] CreateOrUpdateFinishedRequest request)
        {
            FinishProduct finishProduct = mapper.Map<CreateOrUpdateFinishedRequest, FinishProduct>(request);

            _ = unitOfWork.FinishedRepository.Add(finishProduct);

            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFinishProduct(Guid id, [FromBody] CreateOrUpdateFinishedRequest request)
        {
            FinishProduct? finishProduct = await unitOfWork.FinishedRepository.GetByGuidAsync(id);
            if (finishProduct == null)
            {
                return NotFound();
            }
            _ = mapper.Map(request, finishProduct);

            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFinishProduct([FromQuery] Guid[] ids)
        {
            foreach (Guid id in ids)
            {
                FinishProduct? finishProduct = await unitOfWork.FinishedRepository.GetByGuidAsync(id);
                if (finishProduct == null)
{
                    return NotFound();
                }
                _ = await unitOfWork.FinishedRepository.DeleteAsync(finishProduct);
            }
            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }
    }
}
