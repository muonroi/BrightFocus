

namespace BrightFocus.Core.Interfaces.Repository.ImportExportTask
{
    public interface IImportRepository : IMRepository<ImportEntity>
    {
        Task<bool> UpdateWarehouseVolumesAsync(IEnumerable<UpdateWarehouseRequest> updates, CancellationToken cancellationToken);
    }
}
