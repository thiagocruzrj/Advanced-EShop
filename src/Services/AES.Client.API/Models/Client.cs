using AES.Core.DomainObjects;

namespace AES.Client.API.Models
{
    public class Client : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public bool Excluded { get; private set; }
        public Address Address { get; private set; }

        public Client(string name, string email, string cpf)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
            Excluded = false;
        }
    }

    public class Address : Entity
    {
        public string PublicPlace { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string Cep { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public Address(string publicPlace, string number, string complement, string neighborhood, string cep, string city, string state)
        {
            PublicPlace = publicPlace;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            Cep = cep;
            City = city;
            State = state;
        }
    }
}
