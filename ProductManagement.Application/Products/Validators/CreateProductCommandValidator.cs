using FluentValidation;
using ProductManagement.Application.Products.Commands;

namespace ProductManagement.Application.Products.Validators;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {

        RuleFor(x => x.ProductRequest)
            .NotNull().WithMessage("Product's detail is required for update.");

        RuleFor(x => x.ProductRequest.Name)
            .NotEmpty().WithMessage("Product name is required.");

        RuleFor(x => x.ProductRequest.Price)
            .GreaterThan(0).WithMessage("Product price must be greater than 0.");

        RuleFor(x => x.ProductRequest.ProductCategoryId)
            .NotEmpty().WithMessage("Product category is required.");
    }
}

