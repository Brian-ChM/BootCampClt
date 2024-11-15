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
    public DbSet<Entity> Entities { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CustomerEntity> CustomerEntities { get; set; }
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new CardConfiguration());
        modelBuilder.ApplyConfiguration(new ChargeConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
        modelBuilder.ApplyConfiguration(new EntityConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
