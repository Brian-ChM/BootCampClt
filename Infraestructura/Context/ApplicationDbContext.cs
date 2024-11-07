using Core.Entities;
using Infraestructura.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Context;

public partial class ApplicationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public ApplicationDbContext() { }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
