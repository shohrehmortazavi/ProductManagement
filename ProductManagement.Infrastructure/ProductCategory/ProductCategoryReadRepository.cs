using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Domains.ProductCategories;
using ProductManagement.Infrastructure.Base;
using ProductManagement.Infrastructure.Data;


namespace ProductCategoryManagement.Infrastructure.ProductCategoryCategory;

public class ProductCategoryReadRepository : BaseReadRepository<ProductCategory>, IProductCategoryReadRepository
{
    private readonly ProductManagmentDbContext _context;

    public ProductCategoryReadRepository(ProductManagmentDbContext context) : base(context) => _context = context ?? throw new ArgumentNullException(nameof(context));

}

