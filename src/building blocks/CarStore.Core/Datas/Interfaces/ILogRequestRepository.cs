using CarStore.Core.DomainObjects;

namespace CarStore.Core.Datas.Interfaces;

public interface ILogRequestRepository  
{
    Task Add(LogRequest entity);
    Task Update(LogRequest entity);
    IUnitOfWork UnitOfWork { get; }
}