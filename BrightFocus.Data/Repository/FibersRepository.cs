

namespace BrightFocus.Data.Repository
{
    public class FibersRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<Fiber>(dbContext, authContext), IFibersRepository
    {
        public async Task<MResponse<MPagedResult<FibersInListDto>>> GetFiberListPagingAsync(int pageIndex, int pageSize, string keyword)
        {
            MResponse<MPagedResult<FibersInListDto>> result = new();
            IQueryable<Fiber> query = dbContext.Fibers.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Type.Contains(keyword));
            }

            int rowCount = await query.CountAsync();

            IQueryable<Fiber> items = query
                .OrderBy(x => x.Type)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            MPagedResult<FibersInListDto> data = new()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = rowCount,
                Items = [.. mapper.ProjectTo<FibersInListDto>(items)]
            };
            result.Result = data;
            return result;
        }
    }
}
