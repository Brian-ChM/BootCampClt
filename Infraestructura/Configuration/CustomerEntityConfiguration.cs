using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configuration;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> entity)
    {
        entity.HasKey(e => e.Id);

        entity
            .HasOne(e => e.Entity)
            .WithMany(e => e.CustomerEntities)
            .HasForeignKey(e => e.EntityId);

        entity
            .HasOne(e => e.Customer)
            .WithMany(e => e.CustomerEntities)
            .HasForeignKey(e => e.CustomerId);
    }
}
