using CarStore.Shop.Domain.Models;

namespace CarStore.Shop.Domain.Interfaces;

public interface IVehicleService : IDisposable
{
    Task<bool> Add(Vehicle model);
    Task<bool> Update(Vehicle model);
}