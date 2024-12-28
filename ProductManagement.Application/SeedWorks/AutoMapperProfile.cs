using AutoMapper;
using ProductManagement.Application.Products.Commands;
using ProductManagement.Application.Products.Dtos;
using ProductManagement.Domain.Domains.Products;

namespace ProductManagement.Application.SeedWorks;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductResponseDto>();

        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
    }
}
