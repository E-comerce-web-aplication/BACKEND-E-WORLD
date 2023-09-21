using Microsoft.EntityFrameworkCore;
using inventory.ArqLimpia.EN;
namespace Inventary.ArqLimpia.DAL
{
    public class InventoryContextDAL: DbContext
    {
        public DbSet<ProductEN> Products { get; set; }
        public DbSet<UserEN> Users { get; set; }
        public DbSet<StoreEN> Stores { get; set; }
        public DbSet<ProductStoreEN> ProductStore { get; set; }
        public DbSet<OrdersEN> Order { get; set; }
        public DbSet<OrdersProductEN> OrderProduct { get; set; }
        public DbSet<UserStoreEN> UserStore { get; set; }
        public DbSet<RegisterEN> Register { get; set; }
        public DbSet<ProductRegisterEN> ProductRegister { get; set; }
        public DbSet<ReturnsEN> Returns { get; set; }
        public DbSet<ProductsReturnEN> ProductReturn { get; set; }

        public InventoryContextDAL(DbContextOptions<InventoryContextDAL> options): base(options){}
    }
}