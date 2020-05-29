using AES.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AES.Clients.API.Models
{
    public interface IClientRepository : IRepository<Client>
    {
        void Add(Client client);
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetByCpf(string cpf);
    }
}
