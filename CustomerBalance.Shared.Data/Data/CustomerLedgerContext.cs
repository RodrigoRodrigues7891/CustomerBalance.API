using CustomerBalance.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerBalance.Shared.Data.Data;

public class CustomerLedgerContext : DbContext
{
    public DbSet<CustomerLedger> CustomerLedgers { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CustomerLedgerV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public CustomerLedgerContext()
    {

    }
    public CustomerLedgerContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerLedger>()
            .HasKey(c => new { c.AN8, c.DCT, c.DOC });

        modelBuilder.Entity<CustomerLedger>()
        .Property(c => c.AG)
        .HasPrecision(15, 2);

        modelBuilder.Entity<CustomerLedger>()
            .Property(c => c.AAP)
            .HasPrecision(15, 2);

        modelBuilder.Entity<CustomerLedger>()
            .Property(c => c.AAR)
            .HasPrecision(15, 2);
    }
}
