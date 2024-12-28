using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using ProductManagement.Domain.Domains.ProductCategories;
using ProductManagement.Domain.Domains.Products;
using ProductManagement.Infrastructure.Data;

namespace ProductManagement.Infrastructure.SeedWorks;

public static class InitialDb
{
    public static void EnsureMigrationOfContext<T>(this IApplicationBuilder app) where T :
        ProductManagmentDbContext
    {

        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var _context = serviceScope.ServiceProvider.GetService<T>();
            _context.Database.Migrate();
            var productCategories=new List<ProductCategory>();

            if (!_context.ProductCategories.Any())
            {
                productCategories = GenerateProductCategories(10);
                _context.ProductCategories.AddRange(productCategories);
                _context.SaveChanges();
            }
            else
                productCategories.AddRange(_context.ProductCategories.Take(10));

            if (!_context.Products.Any())
            {
                var productList = new List<Product>();
                foreach (var category in productCategories)
                {
                    var products = GenerateProducts(3, new List<Guid> { category.Id });
                    productList.AddRange(products);
                }
                _context.Products.AddRange(productList);
                _context.SaveChanges();
            }
        }
    }

    public static List<ProductCategory> GenerateProductCategories(int count)
    {
        var categoryFaker = new Faker<ProductCategory>()
            .CustomInstantiator(f => new ProductCategory(f.Commerce.Categories(1).First()));

        return categoryFaker.Generate(count);
    }
    public static List<Product> GenerateProducts(int count, List<Guid> categoryIds)
    {
        var productFaker = new Faker<Product>()
            .CustomInstantiator(f =>new Product( f.Commerce.ProductName(),
                                                 f.Finance.Amount(10, 1000),
                                                 f.PickRandom(categoryIds)));

        return productFaker.Generate(count);
    }
}