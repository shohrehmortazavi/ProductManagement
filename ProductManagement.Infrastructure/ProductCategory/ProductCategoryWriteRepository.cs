using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Domains.ProductCategories;
using ProductManagement.Infrastructure.Base;
using ProductManagement.Infrastructure.Data;


namespace ProductCategoryManagement.Infrastructure.ProductCategoryCategory;

public class ProductCategoryWriteRepository : BaseWriteRepository<ProductCategory>, IProductCategoryWriteRepository
{
    private readonly ProductManagmentDbContext _context;

    public ProductCategoryWriteRepository(ProductManagmentDbContext context) : base(context) => _context = context ?? throw new ArgumentNullException(nameof(context));

}

