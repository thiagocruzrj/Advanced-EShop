using AES.Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AES.Catalog.API.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
