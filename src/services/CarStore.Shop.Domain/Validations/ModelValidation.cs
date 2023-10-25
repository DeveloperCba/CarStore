using CarStore.Shop.Domain.Models;
using FluentValidation;

namespace CarStore.Shop.Domain.Validations;

public class ModelValidation : AbstractValidator<Model>
{
    public ModelValidation()
    {
        RuleFor(m => m.Description)
            .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
            .Length(2, 50).WithMessage("The field {PropertyName} need to be between {MinLength} e {MaxLength} characters");

        RuleFor(m => m.YearManufacturing)
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("The field {PropertyName} must be less than " + (DateTime.Now.Year))
            .GreaterThan(1950).WithMessage("The field {PropertyName} must be greater than or equal to zero");

        RuleFor(m => m.YearModel)
            .LessThan(DateTime.Now.Year + 2).WithMessage("The field {PropertyName} must be less than " + (DateTime.Now.Year + 2))
            .GreaterThan(1950).WithMessage("The field {PropertyName} must be greater than or equal to zero");
    }
}