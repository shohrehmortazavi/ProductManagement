using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Domains.Products;
using ProductManagement.Infrastructure.Base;
using ProductManagement.Infrastructure.Data;

namespace ProductManagement.Infrastructure.Products;

public class ProductReadRepository : BaseReadRepository<Product>, IProductReadRepository
{
    private readonly ProductManagmentDbContext _context;

    public ProductReadRepository(ProductManagmentDbContext context) : base(context) => _context = context ?? throw new ArgumentNullException(nameof(context));
}
