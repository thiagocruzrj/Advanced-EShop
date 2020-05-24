using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AES.Client.API.Models
{
    public class Client
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public bool Excluded { get; private set; }
        public Address Address { get; private set; }
    }

    public class Address
    {
    }
}
