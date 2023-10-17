using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Inventory.ArqLimpia.EN.Interfaces;
using Inventory.EN.Enterprice;

namespace Inventary.ArqLimpia.DAL
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoDBSettings = configuration.GetSection("MongoDBSettings");
            var connectionString = mongoDBSettings.GetValue<string>("ConnectionString");
            var databaseName = mongoDBSettings.GetValue<string>("DatabaseName");

            services.AddSingleton<InventoryContextDAL>(provider =>
            {
                return new InventoryContextDAL(connectionString, databaseName);
            });

            services.AddScoped<IProduct, ProductsDAL>();
            services.AddScoped<IOrder, OrderDAL>();
            services.AddScoped<ICompany, CompanyDAL>();
            return services;
        }
    }
}

    