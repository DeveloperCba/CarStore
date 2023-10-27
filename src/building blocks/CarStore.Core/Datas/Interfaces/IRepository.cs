using CarStore.Core.DomainObjects;

namespace CarStore.Core.Datas.Interfaces;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}