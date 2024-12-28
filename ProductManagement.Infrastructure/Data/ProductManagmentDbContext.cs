using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Domains.ProductCategories;
using ProductManagement.Domain.Domains.Products;

namespace ProductManagement.Infrastructure.Data;

public class ProductManagmentDbContext : DbContext
{
    public ProductManagmentDbContext(DbContextOptions<ProductManagmentDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
