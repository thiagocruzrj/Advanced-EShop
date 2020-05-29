using AES.Clients.API.Data;
using AES.Clients.API.Models;
using AES.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AES.Clients.API.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientesContext _context;
        public IUnitOfWork IUnitOfWork => _context; 

        public ClientRepository(ClientesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients.AsNoTracking().ToListAsync();
        }

        public void Add(Client client)
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
