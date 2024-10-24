

namespace BrightFocus.Core.Interfaces
{
    public interface IPaperTubeRepository : IMRepository<PaperTube>
    {
        Task<MResponse<MPagedResult<PaperTubeInListDto>>> GetPaperTubeListPagingAsync(int pageIndex, int pageSize, string keyword);
    }
}
