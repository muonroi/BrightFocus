



namespace BrightFocus.Data.Repository
{
    public class ImportRepository(BrightFocusDbContext dbContext, MAuthenticateInfoContext authContext)
                : MRepository<ImportEntity>(dbContext, authContext), IImportRepository
    {
        public async Task<bool> UpdateWarehouseVolumesAsync(IEnumerable<UpdateWarehouseRequest> updates, CancellationToken cancellationToken)
        {
            List<Guid> entityIds = updates.Select(u => u.EntityId).ToList();
            List<ImportEntity> warehouses = await Queryable
                    .Where(w => entityIds.Contains(w.EntityId))
                    .ToListAsync(cancellationToken);

            foreach (ImportEntity? warehouse in warehouses)
            {
                UpdateWarehouseRequest? update = updates.FirstOrDefault(u => u.EntityId == warehouse.EntityId);
                if (update != null)
                {
                    warehouse.Volume -= update.Volume;
                    warehouse.Note = update.Note;
                }
            }
            bool result = await _dbBaseContext.SaveChangesAsync(cancellationToken) > 0;
            return result;

        }
    }
}
