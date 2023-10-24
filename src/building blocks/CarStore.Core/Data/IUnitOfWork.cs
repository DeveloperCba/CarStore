namespace CarStore.Core.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}