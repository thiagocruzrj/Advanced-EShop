using AES.Core.Messages;
using FluentValidation;
using System;

namespace AES.Clients.API.Application.Commands
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

        public override bool IsValid()
        {
            ValidationResult = new RegisterClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RegisterClientValidation : AbstractValidator<RegisterClientCommand>
    {
        public RegisterClientValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Client Id invalid");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("The client name was not filled");

            RuleFor(c => c.Cpf)
                .Must(HasValidCpf)
                .WithMessage("Invalid CPF");

            RuleFor(c => c.Email)
                .Must(HasValidEmail)
                .WithMessage("Invalid Email");
        }

        protected static bool HasValidCpf(string cpf)
        {
            return Core.DomainObjects.Cpf.Validate(cpf);
        }

        protected static bool HasValidEmail(string email)
        {
            return Core.DomainObjects.Email.Validate(email);
        }
    }
}