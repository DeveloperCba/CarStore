namespace CarStore.Core.Datas.Interfaces;

public interface IUnitOfWork
{
    Task<bool> Commit();
}