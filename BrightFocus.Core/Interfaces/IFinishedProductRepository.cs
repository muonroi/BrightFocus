

namespace BrightFocus.Core.Interfaces
{
    public interface IFinishedProductRepository : IMRepository<FinishProduct>
    {
        Task<MResponse<MPagedResult<FinishedProductInListDto>>> GetFinishedListPagingAsync(int pageIndex, int pageSize, string keyword);
    }
}
