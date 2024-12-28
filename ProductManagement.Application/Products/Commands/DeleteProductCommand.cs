using FluentValidation;
using MediatR;
using ProductManagement.Domain.Domains.Products;

namespace ProductManagement.Application.Products.Commands;
public record DeleteProductCommand(Guid Id) : IRequest<bool>;

public class DeleteProductCommandHandler(IProductWriteRepository productWriteRepository,
                                         IProductReadRepository productReadRepository, 
                                         IValidator<DeleteProductCommand> validator) : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductWriteRepository _productWriteRepository = productWriteRepository;
    private readonly IProductReadRepository _productReadRepository = productReadRepository;
    private readonly IValidator<DeleteProductCommand> _validator = validator;

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await _productReadRepository.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Product not found.");
      
        await _productWriteRepository.SoftDeleteAsync(product);
    
        return true;
    }
}
