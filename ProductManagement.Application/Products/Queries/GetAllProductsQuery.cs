using AutoMapper;
using MediatR;
using ProductManagement.Application.Products.Dtos;
using ProductManagement.Domain.Domains.Products;

namespace ProductManagement.Application.Products.Queries;

public record GetAllProductsQuery() : IRequest<IEnumerable<ProductResponseDto>>;


public class GetAllProductsQueryHandler(IProductReadRepository productReadRepository, IMapper mapper) : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponseDto>>
{
    private readonly IProductReadRepository _productReadRepository = productReadRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ProductResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productReadRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
    }
}
