using AutoMapper;
using FluentValidation;
using MediatR;
using ProductManagement.Application.Products.Dtos;
using ProductManagement.Domain.Domains.Products;

namespace ProductManagement.Application.Products.Commands;

public record UpdateProductCommand(ProductRequestDto ProductRequest) : IRequest<ProductResponseDto>;

public class UpdateProductCommandHandler(IProductWriteRepository productWriteRepository,
                                         IProductReadRepository productReadRepository,
                                         IValidator<UpdateProductCommand> validator,
                                         IMapper mapper) : IRequestHandler<UpdateProductCommand, ProductResponseDto>
{
    private readonly IProductWriteRepository _productWriteRepository = productWriteRepository;
    private readonly IProductReadRepository _productReadRepository = productReadRepository;
    private readonly IValidator<UpdateProductCommand> _validator = validator;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {

        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);


        var requestedProduct = request.ProductRequest;
   
        var product = await _productReadRepository.GetByIdAsync(requestedProduct.Id.Value) ?? 
                            throw new KeyNotFoundException("Product not found.");
      
        product.Update(requestedProduct.Name, requestedProduct.Price, requestedProduct.ProductCategoryId);
        await _productWriteRepository.UpdateAsync(product);

        var response = _mapper.Map<ProductResponseDto>(product);
        return response;
    }
}
