using Lab13.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Detail> Details { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.IdCustomers);

        modelBuilder.Entity<Product>()
            .HasKey(p => p.IdProducts);

        modelBuilder.Entity<Invoice>()
            .HasKey(i => i.IdInvoices);

        modelBuilder.Entity<Detail>()
            .HasKey(d => d.IdDetails);

        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.Customer)
            .WithMany(c => c.Invoices)
            .HasForeignKey(i => i.IdCustomers);

        modelBuilder.Entity<Detail>()
            .HasOne(d => d.Invoice)
            .WithMany(i => i.Details)
            .HasForeignKey(d => d.Invoices_IdInvoices);

        modelBuilder.Entity<Detail>()
            .HasOne(d => d.Product)
            .WithMany(p => p.Details)
            .HasForeignKey(d => d.Products_IdProducts);
    }
}
