using AES.Core.Messages;
using FluentValidation;
using System;

namespace AES.Clients.API.Commands
{
    public class RegisterClientCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public RegisterClientCommand(Guid id, string name, string email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf;
        }
    }

    public class RegisterClientValidation : AbstractValidator<RegisterClientCommand>
    {
        public RegisterClientValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Client Id invalid");
        }
    }
}