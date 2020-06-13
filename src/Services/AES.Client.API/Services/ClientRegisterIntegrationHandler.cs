using AES.Clients.API.Application.Commands;
using AES.Core.Mediator;
using AES.Core.Messages.Integration;
using EasyNetQ;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AES.Clients.API.Services
{
    public class ClientRegisterIntegrationHandler : BackgroundService
    {
        private IBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public ClientRegisterIntegrationHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus("host=localhost:5672");

            _bus.RespondAsync<UserRegisteredIntegrationEvent, ResponseMessage>(async request =>
                new ResponseMessage(await RegisterClient(request)));

            return Task.CompletedTask;
        }

        private async Task<ValidationResult> RegisterClient(UserRegisteredIntegrationEvent message)
        {
            var clientCommand = new RegisterClientCommand(message.Id, message.Name, message.Email, message.Cpf);
            ValidationResult success;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                success = await mediator.SendCommand(clientCommand);
            }

            return success;
        }
    }
}
