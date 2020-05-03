using AES.Identity.API.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AES.Identity.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var buider = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                buider.AddUserSecrets<Startup>();
            }

            Configuration = buider.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfiguration(Configuration);
            services.AddSwaggerConfiguration();
            services.AddApiConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseIdentityConfiguration();
            app.UseSwaggerConfiguration();
            app.UseApiConfiguration(env);
        }
    }
}
