using CarStore.Core.Messages;
using FluentValidation.Results;

namespace CarStore.Core.Mediator;
public interface IMediatorHandler
{
    Task Publish<T>(T @event) where T : Event;
    Task<ValidationResult> Send<T>(T command) where T : Command;
}
