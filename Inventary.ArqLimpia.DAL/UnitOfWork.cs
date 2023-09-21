using Inventory.ArqLimpia.EN.Interfaces;



namespace Inventary.ArqLimpia.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly InventoryContextDAL dbContext;

        public UnitOfWork(InventoryContextDAL pDbContext)
        {
            dbContext = pDbContext;
        }
        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();

        }
    }
}
