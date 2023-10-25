using CarStore.Core.DomainObjects;
using FluentValidation;
using FluentValidation.Results;

namespace CarStore.Shop.Domain.Services;

public abstract class BaseService
{
    private readonly INotify _notify;

    protected BaseService(INotify notify) => _notify = notify;

    protected void Notify(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
            Notify(error.ErrorMessage);
    }

    protected void Notify(string mensagem) => _notify.Handler(new NotificationMessage(mensagem));

    protected bool RunValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
    {
        var validator = validacao.Validate(entidade);

        if (validator.IsValid) return true;

        Notify(validator);

        return false;
    }
}
