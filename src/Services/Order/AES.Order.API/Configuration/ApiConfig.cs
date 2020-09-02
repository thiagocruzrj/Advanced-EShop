using AES.Order.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AES.Order.API.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddCors(o =>
            {
                o.AddPolicy("Total",
                    b => b.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyMethod());
            });
        }
    }
}
