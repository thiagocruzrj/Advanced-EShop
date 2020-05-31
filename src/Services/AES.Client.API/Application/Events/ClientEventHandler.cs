using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AES.Clients.API.Application.Events
{
    public class ClientEventHandler : INotificationHandler<ClientRegisteredEvent>
    {
        public Task Handle(ClientRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Send confirmation event
            return Task.CompletedTask;
        }
    }
}