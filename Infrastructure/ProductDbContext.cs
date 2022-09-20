using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    } 
    
    public DbSet<Product> ProductTable { get; set; }
}