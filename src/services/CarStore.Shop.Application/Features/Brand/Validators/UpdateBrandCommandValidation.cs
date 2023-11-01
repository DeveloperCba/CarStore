using CarStore.Shop.Application.Features.Brand.Commands;
using FluentValidation;

namespace CarStore.Shop.Application.Features.Brand.Validators;

public class UpdateBrandCommandValidation : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidation()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("The field {PropertyName} need to be provided")
            //.Must(BeValidGuid).WithMessage("Invalid  {PropertyName} format.")
            ;



        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("The field {PropertyName} need to be provided")
            .Length(2, 50).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");

        RuleFor(c => c.Status)
            .GreaterThan(-1).WithMessage("The field {PropertyName} must be greater than or equal to zero");
    }


    private bool BeValidGuid(Guid id)
    {
        return id != Guid.Empty;
    }
}
