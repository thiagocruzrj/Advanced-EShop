using AES.Clients.API.Models;
using AES.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AES.Clients.API.Data.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(c => c.Cpf, tf =>
            {
                tf.Property(c => c.Number)
                    .IsRequired()
                    .HasMaxLength(Cpf.CpfMaxLength)
                    .HasColumnName("Cpf")
                    .HasColumnType($"varchar({Cpf.CpfMaxLength})");
            });

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.Address)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.AddressMaxLength})");
            });

            // 1 : 1 => Client : Address
            builder.HasOne(c => c.Address)
                .WithOne(c => c.Client);

            builder.ToTable("Clients");
        }
    }
}
