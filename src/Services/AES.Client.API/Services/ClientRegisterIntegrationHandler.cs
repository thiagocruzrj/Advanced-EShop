using AES.Core.Messages.Integration;
using EasyNetQ;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AES.Clients.API.Services
{
    public class ClientRegisterIntegrationHandler : BackgroundService
    {
        private IBus _bus;

        public ClientRegisterIntegrationHandler(IBus bus)
        {
            _bus = bus;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus("hostlocalhost:5672");

            _bus.RespondAsync<UserRegisteredIntegrationEvent, ResponseMessage>(async request =>
                new ResponseMessage());

            return Task.CompletedTask;
        }
    }
}
