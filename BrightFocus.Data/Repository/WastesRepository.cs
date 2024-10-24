

namespace BrightFocus.Data.Repository
{
    public class WastesRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext, IMapper mapper) : MRepository<WastesProduct>(dbContext, authContext), IWastesRepository
    {
        public async Task<MResponse<MPagedResult<WastesInListDto>>> GetWastesListPagingAsync(int pageIndex, int pageSize, string keyword)
        {
            MResponse<MPagedResult<WastesInListDto>> result = new();
            IQueryable<WastesProduct> query = dbContext.WasteProducts.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.ClothType.Contains(keyword));
            }

            int rowCount = await query.CountAsync();

            IQueryable<WastesProduct> items = query
                .OrderBy(x => x.ClothType)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            MPagedResult<WastesInListDto> data = new()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = rowCount,
                Items = [.. mapper.ProjectTo<WastesInListDto>(items)]
            };
            result.Result = data;
            return result;
        }
    }
}
