using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AES.Clients.API.Commands
{
    public class ClientCommandHandler : IRequestHandler<RegisterClientCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegisterClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            return message.ValidationResult;
        }
    }
}