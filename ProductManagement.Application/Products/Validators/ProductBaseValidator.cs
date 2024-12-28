using FluentValidation;
using ProductManagement.Application.Products.Dtos;

namespace ProductManagement.Application.Products.Validators;

public class ProductBaseValidator : AbstractValidator<ProductRequestDto>
{
    public ProductBaseValidator()
    {
        RuleFor(x => x)
            .NotNull().WithMessage("Product's detail is required for update.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Product price must be greater than 0.");

        RuleFor(x => x.ProductCategoryId)
            .NotEmpty().WithMessage("Product category is required.");
    }
}