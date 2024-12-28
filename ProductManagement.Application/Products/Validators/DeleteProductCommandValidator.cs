using FluentValidation;
using ProductManagement.Application.Products.Commands;

namespace ProductManagement.Application.Products.Validators;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
                   .Must(id => id != Guid.Empty)
                   .WithMessage("Product ID must be a valid GUID.");
    }
}
