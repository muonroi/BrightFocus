

namespace BrightFocus.Data.Repository
{
    public class WoodsRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<Wood>(dbContext, authContext), IWoodsRepository
    {
        public async Task<MResponse<MPagedResult<WoodsInListDto>>> GetWoodListPagingAsync(int pageIndex, int pageSize, string keyword)
        {
            MResponse<MPagedResult<WoodsInListDto>> result = new();
            IQueryable<Wood> query = dbContext.Woods.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.ClothType.Contains(keyword));
            }

            int rowCount = await query.CountAsync();

            IQueryable<Wood> items = query
                .OrderBy(x => x.ClothType)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            MPagedResult<WoodsInListDto> data = new()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = rowCount,
                Items = [.. mapper.ProjectTo<WoodsInListDto>(items)]
            };
            result.Result = data;
            return result;
        }
    }
}
