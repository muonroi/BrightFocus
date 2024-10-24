


namespace BrightFocus.Core.Interfaces
{
    public interface IWastesRepository : IMRepository<WastesProduct>
    {
        Task<MResponse<MPagedResult<WastesInListDto>>> GetWastesListPagingAsync(int pageIndex, int pageSize, string keyword);
    }
}
