using AES.Catalog.API.Data;
using AES.Catalog.API.Data.Repository;
using AES.Catalog.API.Models;
using Microsoft.Extensions.DependencyInjection;

namespace AES.Catalog.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<CatalogContext>();
        }
    }
}
