using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AES.BFF.Purchases.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.Configure<AppServiceSettings>(configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("Total", builder =>
                                  builder.AllowAnyOrigin()
                                         .AllowAnyMethod()
                                         .AllowAnyHeader());
            });
        }
    }
}
