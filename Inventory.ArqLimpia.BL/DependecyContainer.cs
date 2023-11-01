using Microsoft.Extensions.DependencyInjection;
using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;


namespace Inventory.ArqLimpia.BL
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddBLDependecies(this IServiceCollection services)
        {
            services.AddTransient<IProductBL, ProductsBL>();
            services.AddTransient<IOrderBL, OrderBL>();

            return services;
        }
    }
}
