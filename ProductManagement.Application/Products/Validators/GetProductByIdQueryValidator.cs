using FluentValidation;
using ProductManagement.Application.Products.Queries;

namespace ProductManagement.Application.Products.Validators;

public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(x => x.Id)
                   .Must(id => id != Guid.Empty)
                   .WithMessage("Product ID must be a valid GUID.");
    }
}

