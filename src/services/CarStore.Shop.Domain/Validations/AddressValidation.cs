using CarStore.Shop.Domain.Models;
using FluentValidation;

namespace CarStore.Shop.Domain.Validations;

public class AddressValidation : AbstractValidator<Address>
{
    public AddressValidation()
    {
        RuleFor(c => c.Street)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(2, 200).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");

        RuleFor(c => c.Neighborhood)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(2, 100).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");

        RuleFor(c => c.ZipCode)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(8).WithMessage("The field {PropertyName} need to have {MaxLength} characters");

        RuleFor(c => c.City)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(2, 100).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");

        RuleFor(c => c.State)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(2, 50).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");

        RuleFor(c => c.Number)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(1, 50).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");
    }
}