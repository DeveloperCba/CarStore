using CarStore.Core.Datas.Interfaces;
using FluentValidation.Results;

namespace CarStore.Core.Messages;
public abstract class CommandHandler
{
    protected ValidationResult ValidationResult;

    protected CommandHandler()
    {
        ValidationResult = new ValidationResult();
    }

    protected void AddError(string message)
    {
        ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
    }

    protected async Task<ValidationResult> SendData(IUnitOfWork uow)
    {
        if (!await uow.Commit()) AddError("Houve um erro ao persistir os dados");

        return ValidationResult;
    }
}