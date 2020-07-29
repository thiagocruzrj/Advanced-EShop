using AES.WebApi.Core.Users;
using AES.WebApp.MVC.Extensions;
using AES.WebApp.MVC.Service;
using AES.WebApp.MVC.Service.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;

namespace AES.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            #region HttpServices

            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAuthService, AuthService>()
                .AddPolicyHandler(PollyExtentions.WaitTry())
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            services.AddHttpClient<ICatalogService, CatalogService>()
                    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                    .AddPolicyHandler(PollyExtentions.WaitTry())
                    .AddTransientHttpErrorPolicy(
                        p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));
            #endregion
        }
    }
}