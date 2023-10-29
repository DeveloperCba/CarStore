namespace CarStore.Core.DomainObjects.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException() : base($"Not found.")
    {
    }

    public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key})  not found.")
    {
    }
}