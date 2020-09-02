using AES.Core.Data;
using AES.Core.DomainObjects;
using AES.Core.Mediator;
using AES.Core.Messages;
using AES.Order.Domain.Vouchers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AES.Order.Infra
{
    public class OrderContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediator;

        public OrderContext(DbContextOptions<OrderContext> options, IMediatorHandler mediator) : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<Event>();
            modelBuilder.Ignore<ValidationResult>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            var success = await SaveChangesAsync() > 0;
            if (success) await _mediator.PublishEvents(this);
            return success;
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublishEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notifications)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.CleanEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}