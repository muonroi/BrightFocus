

namespace BrightFocus.Data.Repository
{
    public class FinishedProductRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<FinishProduct>(dbContext, authContext), IFinishedProductRepository
    {
        public async Task<MResponse<MPagedResult<FinishedProductInListDto>>> GetFinishedListPagingAsync(int pageIndex, int pageSize, string keyword)
        {
            MResponse<MPagedResult<FinishedProductInListDto>> result = new();
            IQueryable<FinishProduct> query = dbContext.FinishProducts.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.ClothType.Contains(keyword));
            }

            int rowCount = await query.CountAsync();

            IQueryable<FinishProduct> items = query
                .OrderBy(x => x.ClothType)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            MPagedResult<FinishedProductInListDto> data = new()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = rowCount,
                Items = [.. mapper.ProjectTo<FinishedProductInListDto>(items)]
            };
            result.Result = data;
            return result;
        }
    }
}
