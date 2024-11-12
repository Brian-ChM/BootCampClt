using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configuration;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> entity)
    {
        entity.HasKey(e => e.CardId);

        entity
            .Property(e => e.CardType)
            .IsRequired();

        entity
            .Property(e => e.CardNumber)
            .IsRequired();

        entity
            .Property(e => e.ExpirationDate)
            .IsRequired();

        entity
            .Property(e => e.CreditLimit)
            .IsRequired();

        entity
            .Property(e => e.AvailableCredit)
            .IsRequired();

        entity
            .Property(e => e.Status)
            .IsRequired();

        entity
            .Property(e => e.InterestRate)
            .IsRequired();

        entity
            .HasOne(e => e.Customer)
            .WithMany(e => e.Cards)
            .HasForeignKey(e => e.CustomerId);

        entity
            .HasMany(e => e.Charges)
            .WithOne(e => e.Card)
            .HasForeignKey(e => e.CardId);

        entity
           .HasMany(e => e.Payments)
           .WithOne(e => e.Card)
           .HasForeignKey(e => e.CardId);
    }
}
