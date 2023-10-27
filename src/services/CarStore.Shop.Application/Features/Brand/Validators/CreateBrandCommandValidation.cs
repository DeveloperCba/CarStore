using CarStore.Shop.Application.Features.Brand.Commands;
using FluentValidation;

namespace CarStore.Shop.Application.Features.Brand.Validators;

public class CreateBrandCommandValidation : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidation()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(2, 50).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");

        RuleFor(c=>c.Status)
            .GreaterThan(-1).WithMessage("The field {PropertyName} must be greater than or equal to zero");
    }
}
