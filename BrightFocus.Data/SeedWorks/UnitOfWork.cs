



namespace BrightFocus.Data.SeedWorks
{
    public class UnitOfWork(BrightFocusDbContext context) : IUnitOfWork
    {
        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
