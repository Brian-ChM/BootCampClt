using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configuration;

public class EntityConfiguration : IEntityTypeConfiguration<Entity>
{
    public void Configure(EntityTypeBuilder<Entity> entity)
    {
        entity.HasKey(e => e.Id);

        entity
            .Property(e => e.EntityName)
            .IsRequired();

        entity
            .HasMany(e => e.Products)
            .WithOne(e => e.Entity)
            .HasForeignKey(e => e.EntityId);

        entity
            .HasMany(e => e.CustomerEntities)
            .WithOne(e => e.Entity)
            .HasForeignKey(e => e.EntityId);
    }
}
