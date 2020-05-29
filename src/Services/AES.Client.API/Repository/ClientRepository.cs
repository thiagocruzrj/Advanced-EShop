using AES.Clients.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AES.Clients.API.Repository
{
    public class ClientRepository : IClientRepository
    {
        public void Add(Client client)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Client> GetByCpf(string cpf)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
