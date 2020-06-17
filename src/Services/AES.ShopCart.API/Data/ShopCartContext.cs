using AES.ShopCart.API.Model;
using Microsoft.EntityFrameworkCore;

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
    }
}
