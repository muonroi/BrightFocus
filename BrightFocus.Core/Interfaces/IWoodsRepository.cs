

namespace BrightFocus.Core.Interfaces
{
    public interface IWoodsRepository : IMRepository<Wood>
    {
        Task<MResponse<MPagedResult<WoodsInListDto>>> GetWoodListPagingAsync(int pageIndex, int pageSize, string keyword);
    }
}
