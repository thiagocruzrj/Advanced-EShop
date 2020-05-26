using System;

namespace AES.Clients.API.Commands
{
    public class RegisterClientCommand
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
    }
}
