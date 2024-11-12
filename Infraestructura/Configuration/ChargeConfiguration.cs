using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configuration;

public class ChargeConfiguration : IEntityTypeConfiguration<Charge>
{
    public void Configure(EntityTypeBuilder<Charge> entity)
    {
        entity.HasKey(e => e.ChargeId);

        entity
            .Property(e => e.ChargeId)
            .IsRequired();

        entity
            .Property(e => e.Amount)
            .IsRequired();

        entity
            .Property(e => e.AvailableCredit)
            .IsRequired();

        entity
            .Property(e => e.Description)
            .IsRequired();

        entity
            .Property(e => e.Date)
            .IsRequired();

        entity
            .HasOne(e => e.Card)
            .WithMany(e => e.Charges)
            .HasForeignKey(e => e.CardId);
    }
}
