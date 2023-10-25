using System.Linq.Expressions;
using CarStore.Core.Data;
using CarStore.Shop.Domain.Models;

namespace CarStore.Shop.Domain.Interfaces;

public interface IVehicleRepository : IRepository<Vehicle>
{
    Task<IEnumerable<Vehicle>> GetAll(Expression<Func<Vehicle, bool>> filter = null);
    Task<Vehicle> GetById(Guid modelId);
    Task<bool> Add(Vehicle model);
    Task<bool> Update(Vehicle model);
    Task<bool> CheckStatus(Guid modelId,TypeStatusVehicle status);
    Task<bool> UpdateBrand(Brand model);
    Task<bool> UpdateOwner(Owner model);
    Task<bool> UpdateModel(Model model);
    Task<Model> GetModelById(Guid id);
    Task<Owner> GetOwnerById(Guid id);
}
