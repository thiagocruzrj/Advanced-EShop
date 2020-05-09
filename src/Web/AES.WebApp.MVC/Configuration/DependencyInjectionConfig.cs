using AES.WebApp.MVC.Service;
using Microsoft.Extensions.DependencyInjection;

namespace AES.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IAuthService, AuthService>();
        }
    }
}
