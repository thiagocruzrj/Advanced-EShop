using AES.Clients.API.Models;
using AES.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AES.Clients.API.Application.Commands
{
    public class ClientCommandHandler : CommandHandler, IRequestHandler<RegisterClientCommand, ValidationResult>
    {
        private readonly IClientRepository _clientRepository;

        public ClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ValidationResult> Handle(RegisterClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var client = new Client(message.Id, message.Name, message.Email, message.Cpf);

            var existingClient = await _clientRepository.GetByCpf(client.Cpf.Number);

            if (existingClient != null)
            {
                AddError("This CPF already in use");
                return ValidationResult;
            }

            _clientRepository.Add(client);

            return await PersistData(_clientRepository.UnitOfWork);
        }
    }
}