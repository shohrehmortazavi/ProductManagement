using AutoMapper;
using FluentValidation;
using MediatR;
using ProductManagement.Application.Products.Dtos;
using ProductManagement.Domain.Domains.Products;

namespace ProductManagement.Application.Products.Commands;

public record CreateProductCommand(ProductRequestDto ProductRequest) : IRequest<ProductResponseDto>;

public class CreateProductCommandHandler(IProductWriteRepository productWriteRepository, 
                                         IValidator<CreateProductCommand> validator, 
                                         IMapper mapper) : IRequestHandler<CreateProductCommand, ProductResponseDto>
{
    private readonly IProductWriteRepository _productWriteRepository = productWriteRepository;
    private readonly IValidator<CreateProductCommand> _validator = validator;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var productRequest = request.ProductRequest;

        var product = new Product(productRequest.Name, productRequest.Price, productRequest.ProductCategoryId);
        await _productWriteRepository.AddAsync(product);

        var response = _mapper.Map<ProductResponseDto>(product);
        return response;
    }
}
