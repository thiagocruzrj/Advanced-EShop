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
            _context.Clients.Add(client);
        }

        public async Task<Client> GetByCpf(string cpf)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Cpf.Number == cpf);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
