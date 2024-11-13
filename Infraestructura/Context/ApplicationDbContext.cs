using Core.Entities;
using Infraestructura.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Context;

public partial class ApplicationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Charge> Charges { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Card> Cards { get; set; }
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new CardConfiguration());
        modelBuilder.ApplyConfiguration(new ChargeConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
