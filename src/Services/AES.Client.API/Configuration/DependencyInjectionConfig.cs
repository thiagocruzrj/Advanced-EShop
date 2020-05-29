using AES.Clients.API.Commands;
using AES.Clients.API.Data;
using AES.Clients.API.Models;
using AES.Clients.API.Repository;
using AES.Core.Mediator;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AES.Clients.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegisterClientCommand, ValidationResult>, ClientCommandHandler>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ClientesContext>();
        }
    }
}
