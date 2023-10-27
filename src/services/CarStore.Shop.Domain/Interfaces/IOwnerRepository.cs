using System.Linq.Expressions;
using CarStore.Core.Datas.Interfaces;
using CarStore.Shop.Domain.Models;

namespace CarStore.Shop.Domain.Interfaces;

public interface IOwnerRepository : IRepository<Owner>
{
    Task<IEnumerable<Owner>> GetAll(Expression<Func<Owner, bool>>? filter = null);
    Task<Owner> GetById(Guid modelId);
    Task Add(Owner model);
    Task Update(Owner model);
    Task<Address> GetAddressById(Guid id);
    Task UpdateAddress(Address model);
}
