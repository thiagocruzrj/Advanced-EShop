using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AES.Identity.API.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
        }

        public static void UseApiConfiguration(this IApplicationBuilder app)
        {

        }
    }
}
