using AutoMapper;
using FluentValidation;
using MediatR;
using ProductManagement.Application.Products.Dtos;
using ProductManagement.Domain.Domains.Products;

namespace ProductManagement.Application.Products.Queries;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductResponseDto>;

public class GetProductByIdQueryHandler(IProductReadRepository productReadRepository, IValidator<GetProductByIdQuery> validator, IMapper mapper) : IRequestHandler<GetProductByIdQuery, ProductResponseDto>
{
    private readonly IProductReadRepository _productReadRepository = productReadRepository;
    private readonly IValidator<GetProductByIdQuery> _validator = validator;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductResponseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await _productReadRepository.GetByIdAsync(request.Id);
        return _mapper.Map<ProductResponseDto>(product);
    }
}