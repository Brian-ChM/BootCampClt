using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> entity)
    {
        entity.HasKey(x => x.Id);

        entity
            .Property(e => e.Number)
            .IsRequired();

        entity
            .Property(e => e.Balance)   
            .IsRequired();

        entity
            .Property(e => e.OpeningDate)
            .IsRequired();

        entity
            .HasOne(e => e.Customer)
            .WithMany(e => e.Accounts)
            .HasForeignKey(e => e.CustomerId);
    }
}
