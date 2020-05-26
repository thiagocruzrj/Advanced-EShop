using System;

namespace AES.Clients.API.Commands
{
    public class RegisterClientCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
    }
}
