





namespace BrightFocus.Controllers
{
    [Route("Chemicals")]
    [ApiVersion("1.0")]
    public class ChemicalController(IMediator mediator, Serilog.ILogger logger
        , IMapper mapper
        , IUnitOfWork unitOfWork,
        IDistributedCache distributedCache) : MControllerBase(mediator, logger)
    {
        [HttpGet]
        public async Task<IActionResult> GetChemicalById([FromQuery] Guid id)
        {
            MResponse<ChemicalsInListDto> response = new();
            ChemicalsInListDto? cache = await distributedCache.GetCacheAsync<ChemicalsInListDto>("Chemicals");
            if (cache != null)
            {
                response.Result = cache;
                return Ok(response);
            }
            Chemicals? chemical = await unitOfWork.ChemicalsRepository.GetByGuidAsync(id);
            if (chemical == null)
            {
                return NotFound();
            }
            ChemicalsInListDto result = mapper.Map<Chemicals, ChemicalsInListDto>(chemical);
            response.Result = result;
            await distributedCache.SetCacheAsync("Chemicals", result, DistributedRedisOptions.DefaultCacheOptions_10_5);
            return Ok(response);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetChemicalListPaging([FromQuery] string keyword, int pageIndex, int pageSize)
        {
            MResponse<MPagedResult<ChemicalsInListDto>> result = await unitOfWork.ChemicalsRepository.GetChemicalListPagingAsync(pageIndex, pageSize, keyword);
            return Ok(result);
        }

        [HttpPost]
        [Permission<Permission>(Permission.Chemist_Create)]
        public async Task<IActionResult> CreateChemical([FromBody] CreateOrUpdateChemicalRequest request)
        {
            Chemicals chemical = mapper.Map<CreateOrUpdateChemicalRequest, Chemicals>(request);

            _ = unitOfWork.ChemicalsRepository.Add(chemical);

            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChemical(Guid id, [FromBody] CreateOrUpdateChemicalRequest request)
        {
            Chemicals? chemical = await unitOfWork.ChemicalsRepository.GetByGuidAsync(id);
            if (chemical == null)
            {
                return NotFound();
            }
            _ = mapper.Map(request, chemical);

            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteChemical([FromQuery] Guid[] ids)
        {
            foreach (Guid id in ids)
            {
                Chemicals? chemical = await unitOfWork.ChemicalsRepository.GetByGuidAsync(id);
                if (chemical == null)
                {
                    return NotFound();
                }
                _ = await unitOfWork.ChemicalsRepository.DeleteAsync(chemical);
            }
            int result = await unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }
    }
}
