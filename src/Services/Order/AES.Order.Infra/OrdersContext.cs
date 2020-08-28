using AES.Core.Data;
using AES.Core.Mediator;
using AES.Core.Messages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AES.Order.Infra
{
    public class OrdersContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediator;

        public OrdersContext(DbContextOptions<OrdersContext> options, IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<Event>();
            modelBuilder.Ignore<ValidationResult>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersContext).Assembly);
        }

        public Task<bool> Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}