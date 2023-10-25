using CarStore.Shop.Domain.Models;

namespace CarStore.Shop.Domain.Interfaces;

public interface IBrandService : IDisposable
{
    Task<bool> Add(Brand model);
    Task<bool> Update(Brand model);
}
