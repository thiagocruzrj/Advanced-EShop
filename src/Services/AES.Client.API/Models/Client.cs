using AES.Core.DomainObjects;
using System;

namespace AES.Clients.API.Models
{
    public class Client : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public bool Excluded { get; private set; }
        public Address Address { get; private set; }

        // Ef relation
        protected Client() { }

        public Client(Guid id, string name, string email, string cpf)
        {
            Id = id;
            Name = name;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            Excluded = false;
        }

        public void ChangeEmail(string email)
        {
            Email = new Email(email);
        }

        public void AssignAddress(Address address)
        {
            Address = address;
        }
    }
}
