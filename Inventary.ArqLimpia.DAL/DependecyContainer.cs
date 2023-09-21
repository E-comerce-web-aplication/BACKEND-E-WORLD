using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Inventory.ArqLimpia.EN.Interfaces;

namespace Inventary.ArqLimpia.DAL
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InventoryContextDAL>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DbConn")));

            services.AddScoped<IProduct, ProductsDAL>();
            services.AddScoped<IUser, UserDAL>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}