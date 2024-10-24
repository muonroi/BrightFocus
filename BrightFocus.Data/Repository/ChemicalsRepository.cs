

namespace BrightFocus.Data.Repository
{
    public class ChemicalsRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<Chemicals>(dbContext, authContext), IChemicalsRepository
    {
        public async Task<MResponse<MPagedResult<ChemicalsInListDto>>> GetChemicalListPagingAsync(int pageIndex, int pageSize, string keyword)
        {
            MResponse<MPagedResult<ChemicalsInListDto>> result = new();
            IQueryable<Chemicals> query = dbContext.Chemicals.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            int rowCount = await query.CountAsync();

            IQueryable<Chemicals> items = query
                .OrderBy(x => x.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            MPagedResult<ChemicalsInListDto> data = new()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = rowCount,
                Items = [.. mapper.ProjectTo<ChemicalsInListDto>(items)]
            };

            result.Result = data;

            return result;
        }
    }
}
