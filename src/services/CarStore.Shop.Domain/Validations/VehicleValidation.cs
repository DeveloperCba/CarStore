using CarStore.Shop.Domain.Models;
using CarStore.Shop.Domain.Validations.Documents;
using FluentValidation;

namespace CarStore.Shop.Domain.Validations;

public class VehicleValidation : AbstractValidator<Vehicle>
{
    public VehicleValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(2, 50).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");

        RuleFor(x => x.Renavam.Length).Equal(RenavamValidacao.TamanhoRenavam)
                .WithMessage("The field Document need to have {ComparisonValue} characters and was provided {PropertyValue}.");

        RuleFor(x => x.BrandId)
            .NotEqual(Guid.Empty).WithMessage("The field {PropertyName} needs to be provided");

        RuleFor(x => x.OwnerId)
            .NotEqual(Guid.Empty).WithMessage("The field {PropertyName} needs to be provided");

        RuleFor(x => x.Kilometer)
            .GreaterThan(-1).WithMessage("The field {PropertyName} must be greater than or equal to zero");

        RuleFor(x => x.Price)
            .GreaterThan(-1).WithMessage("The field {PropertyName} must be greater than or equal to zero");

     }
}
