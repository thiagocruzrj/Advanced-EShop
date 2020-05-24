using AES.Clients.API.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AES.Clients.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ClientesContext>();
        }
    }
}
