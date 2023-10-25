using CarStore.Shop.Domain.Models;
using CarStore.Shop.Domain.Validations.Documents;
using FluentValidation;

namespace CarStore.Shop.Domain.Validations;

public class OwnerValidation : AbstractValidator<Owner>
{
    public OwnerValidation()
    {
        RuleFor(f => f.Name)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(2, 100)
            .WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");

        When(f => f.OwnerType == OwnerType.PhysicalPerson, () =>
        {
            RuleFor(f => f.Document.Length).Equal(CpfValidation.SizeCPF)
                .WithMessage("The field Document need to have {ComparisonValue} characters and was provided {PropertyValue}.");
            RuleFor(f => CpfValidation.Validate(f.Document)).Equal(true)
                .WithMessage("The document provided is invalid.");
        });

        When(f => f.OwnerType == OwnerType.LegalPerson, () =>
        {
            RuleFor(f => f.Document.Length).Equal(CnpjValidation.SizeCNPJ)
                .WithMessage("The field Document need to have {ComparisonValue} characters and was provided {PropertyValue}.");
            RuleFor(f => CnpjValidation.Validate(f.Document)).Equal(true)
                .WithMessage("The document provided is invalid.");
        });

        
        RuleFor(c => c.Address.Street)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(2, 200).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");

        RuleFor(c => c.Address.Neighborhood)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(2, 100).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");

        RuleFor(c => c.Address.ZipCode)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(8).WithMessage("The field {PropertyName} need to have {MaxLength} characters");

        RuleFor(c => c.Address.City)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(2, 100).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");

        RuleFor(c => c.Address.State)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(2, 50).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");

        RuleFor(c => c.Address.Number)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(1, 50).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");
    }
}
