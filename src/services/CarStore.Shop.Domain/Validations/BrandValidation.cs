using CarStore.Shop.Domain.Models;
using FluentValidation;

namespace CarStore.Shop.Domain.Validations;

public class BrandValidation : AbstractValidator<Brand>
{
    public BrandValidation()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(2, 50).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");
    }
}
