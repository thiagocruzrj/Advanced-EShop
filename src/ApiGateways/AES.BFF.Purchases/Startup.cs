using AES.BFF.Purchases.Configuration;
using AES.WebApi.Core.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AES.BFF.Purchases
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(hostEnvironment.ContentRootPath)
                 .AddJsonFile("appsettings.json", true, true)
                 .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                 .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
                builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiConfiguration(Configuration);

            services.AddAuthConfiguration(Configuration);

            services.AddSwaggerConfiguration();

            services.RegisterServices();

            services.AddMessageBusConfiguration(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration();
            app.UseApiConfiguration(env);
        }
    }
}
