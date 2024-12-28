using Microsoft.EntityFrameworkCore;
using ProductCategoryManagement.Infrastructure.ProductCategoryCategory;
using ProductManagement.Application.Products.Validators;
using ProductManagement.Application.SeedWorks;
using ProductManagement.Domain.Base;
using ProductManagement.Domain.Domains.ProductCategories;
using ProductManagement.Domain.Domains.Products;
using ProductManagement.Infrastructure.Base;
using ProductManagement.Infrastructure.Data;
using ProductManagement.Infrastructure.Products;
using FluentValidation;

namespace ProductManagement.Api.SeedWorks;

public static class ServiceCollectionExtensions
{
    private readonly static string Policy = "AllowAll";

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<ProductManagmentDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("ProductManagementConnection")));

    }
    public static IServiceCollection Addservices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options => options.AddPolicy(Policy, p => p.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader()));


        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.Products.Commands.CreateProductCommandHandler).Assembly));

        services.AddValidatorsFromAssemblyContaining<GetProductByIdQueryValidator>();

        services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

        return services;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
        .AddScoped(typeof(IBaseReadRepository<>), typeof(BaseReadRepository<>))
        .AddScoped(typeof(IBaseWriteRepository<>), typeof(BaseWriteRepository<>))
        .AddScoped<IProductReadRepository, ProductReadRepository>()
        .AddScoped<IProductWriteRepository, ProductWriteRepository>()
        .AddScoped<IProductCategoryReadRepository, ProductCategoryReadRepository>()
        .AddScoped<IProductCategoryWriteRepository, ProductCategoryWriteRepository>();

    }

}

