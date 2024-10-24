namespace BrightFocus.Core.Interfaces
{
    public interface IChemicalsRepository : IMRepository<Chemicals>
    {
        Task<MResponse<MPagedResult<ChemicalsInListDto>>> GetChemicalListPagingAsync(int pageIndex, int pageSize, string keyword);
    }
}
