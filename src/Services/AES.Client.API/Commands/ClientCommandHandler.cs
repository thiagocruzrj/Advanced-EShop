using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AES.Clients.API.Commands
{
    public class ClientCommandHandler : IRequestHandler<RegisterClientCommand, ValidationResult>
    {
        public Task<ValidationResult> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void Handler(RegisterClientCommand message) { }
    }
}