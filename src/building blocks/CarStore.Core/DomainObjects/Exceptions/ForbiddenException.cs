namespace CarStore.Core.DomainObjects.Exceptions;

public class ForbiddenException : ApplicationException
{
    public ForbiddenException(string message) : base(message)
    {
    }
}