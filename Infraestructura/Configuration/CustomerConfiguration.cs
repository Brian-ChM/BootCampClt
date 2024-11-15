using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> entity)
    {
        entity.HasKey(x => x.Id);

        entity
            .Property(x => x.FirstName)
            .IsRequired();

        entity
            .HasMany(e => e.Accounts)
            .WithOne(e => e.Customer)
            .HasForeignKey(e => e.CustomerId);

        entity
            .HasMany(e => e.Cards)
            .WithOne(e => e.Customer)
            .HasForeignKey(e => e.CustomerId);

        entity
            .HasMany(e => e.CustomerEntities)
            .WithOne(e => e.Customer)
            .HasForeignKey(e => e.CustomerId);
    }
}
