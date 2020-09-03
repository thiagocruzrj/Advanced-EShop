using AES.Core.Mediator;
using AES.Order.API.Application.Queries;
using AES.Order.Domain.Vouchers;
using AES.Order.Infra;
using AES.Order.Infra.Data;
using AES.WebApi.Core.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AES.Order.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            // Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherQueries, VoucherQueries>();

            // Data
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<OrderContext>();
        }
    }
}