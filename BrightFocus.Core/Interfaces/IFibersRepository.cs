

namespace BrightFocus.Core.Interfaces
{
    public interface IFibersRepository : IMRepository<Fiber>
    {
        Task<MResponse<MPagedResult<FibersInListDto>>> GetFiberListPagingAsync(int pageIndex, int pageSize, string keyword);
    }
}
