using AES.Clients.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AES.Clients.API.Data
{
    public sealed class ClientesContext : DbContext
    {

        public ClientesContext(DbContextOptions<ClientesContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
