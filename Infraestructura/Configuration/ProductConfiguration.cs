using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.HasKey(e => e.Id);

        entity
            .Property(e => e.ProductName)
            .IsRequired();

        entity
            .Property(e => e.Description)
            .IsRequired();

        entity
            .Property(e => e.Status)
            .IsRequired();

        entity
            .Property(e => e.StartDate)
            .IsRequired();

        entity
            .HasOne(e => e.Entity)
            .WithMany(e => e.Products)
            .HasForeignKey(e => e.EntityId);
    }
}
