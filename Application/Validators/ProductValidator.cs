using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class PostProductValidator : AbstractValidator<PostProductDTO>
{
    public PostProductValidator()
    {
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
    }
}

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Id).GreaterThan(0);
    }
}