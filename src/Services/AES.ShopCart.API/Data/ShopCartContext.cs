using AES.ShopCart.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AES.ShopCart.API.Data
{
    public class ShopCartContext : DbContext
    {
        public ShopCartContext(DbContextOptions<ShopCartContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<ShopCartClient> ShopCartClients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Entity<ShopCartClient>()
                .HasIndex(c => c.ClientId)
                .HasName("IDX_Client");

            modelBuilder.Entity<ShopCartClient>()
                .HasMany(c => c.Items)
                .WithOne(i => i.ShopCartClient)
                .HasForeignKey(c => c.ShopCartId);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }
    }
}
