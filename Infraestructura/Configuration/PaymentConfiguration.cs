using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configuration;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> entity)
    {
        entity.HasKey(e => e.PaymentId);

        entity
            .Property(e => e.CardId)
            .IsRequired();

        entity
            .Property(e => e.Amount)
            .IsRequired();

        entity
            .Property(e => e.AvailableCredit)
            .IsRequired();

        entity
            .Property(e => e.Date)
            .IsRequired();

        entity
            .HasOne(e => e.Card)
            .WithMany(e => e.Payments)
            .HasForeignKey(e => e.CardId);
    }
}
