using System.Linq.Expressions;
using CarStore.Core.Data;
using CarStore.Shop.Domain.Models;

namespace CarStore.Shop.Domain.Interfaces;

public interface IOwnerRepository : IRepository<Owner>
{
    Task<IEnumerable<Owner>> GetAll(Expression<Func<Owner, bool>> filter = null);
    Task<Owner> GetById(Guid modelId);
    Task<bool> Add(Owner model);
    Task<bool> Update(Owner model);
    Task<Address> GetAddressById(Guid id);
    Task<bool> UpdateAddress(Address model);
}
