using CarStore.Core.DomainObjects;

namespace CarStore.Core.Datas.Interfaces;

public interface ILogErrorRepository 
{
    Task Add(LogError entity);
    Task Update(LogError entity);
    IUnitOfWork UnitOfWork { get; }
}