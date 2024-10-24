

namespace BrightFocus.Controllers
{
    [Route("Woods")]
    [ApiVersion("1.0")]
    public class WoodController(IMediator mediator, Serilog.ILogger logger
        , IMapper mapper
        , IUnitOfWork unitOfWork) : MControllerBase(mediator, logger)
    {
        [HttpGet]
        public async Task<IActionResult> GetWoodById([FromQuery] Guid id)
        {
            MResponse<WoodsInListDto> response = new();
            Wood? wood = await unitOfWork.WoodsRepository.GetByGuidAsync(id);
            if (wood == null)
            {
                return NotFound();
            }
            WoodsInListDto result = mapper.Map<Wood, WoodsInListDto>(wood);
            response.Result = result;
            return Ok(response);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetWoodListPaging([FromQuery] string keyword, int pageIndex, int pageSize)
        {
            MResponse<MPagedResult<WoodsInListDto>> result = await unitOfWork.WoodsRepository.GetWoodListPagingAsync(pageIndex, pageSize, keyword);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWood([FromBody] CreateOrUpdateWoodRequest request)
        {
            Wood wood = mapper.Map<CreateOrUpdateWoodRequest, Wood>(request);

            _ = unitOfWork.WoodsRepository.Add(wood);

            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWood(Guid id, [FromBody] CreateOrUpdateWoodRequest request)
        {
            Wood? wood = await unitOfWork.WoodsRepository.GetByGuidAsync(id);
            if (wood == null)
            {
                return NotFound();
            }
            _ = mapper.Map(request, wood);

            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWood([FromQuery] Guid[] ids)
        {
            foreach (Guid id in ids)
            {
                Wood? wood = await unitOfWork.WoodsRepository.GetByGuidAsync(id);
                if (wood == null)
                {
                    return NotFound();
                }
                _ = await unitOfWork.WoodsRepository.DeleteAsync(wood);
            }
            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }
    }
}
