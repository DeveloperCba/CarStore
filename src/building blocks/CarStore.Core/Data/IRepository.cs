using CarStore.Core.DomainObjects;

namespace CarStore.Core.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}