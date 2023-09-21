using Inventary.ArqLimpia.DAL;
using Inventory.ArqLimpia.BL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Inventory.ArqLimpia.IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddInventoryDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALDependecies(configuration);
            services.AddBLDependecies();
            return services;
        }

    }
}