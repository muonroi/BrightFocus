

namespace BrightFocus.Data.Repository
{
    public class PaperTubeRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<PaperTube>(dbContext, authContext), IPaperTubeRepository
    {
        public async Task<MResponse<MPagedResult<PaperTubeInListDto>>> GetPaperTubeListPagingAsync(int pageIndex, int pageSize, string keyword)
        {
            MResponse<MPagedResult<PaperTubeInListDto>> result = new();
            IQueryable<PaperTube> query = dbContext.PaperTubes.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Type.Contains(keyword));
            }

            int rowCount = await query.CountAsync();

            IQueryable<PaperTube> items = query
                .OrderBy(x => x.Type)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            MPagedResult<PaperTubeInListDto> data = new()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = rowCount,
                Items = [.. mapper.ProjectTo<PaperTubeInListDto>(items)]
            };
            result.Result = data;
            return result;
        }
    }
}
