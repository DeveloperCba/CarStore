using CarStore.Shop.Domain.Models;

namespace CarStore.Shop.Domain.Interfaces;

public interface IOwnerService : IDisposable
{
    Task<bool> Add(Owner model);
    Task<bool> Update(Owner model);
}
