using System.Linq.Expressions;
using CarStore.Core.Datas.Interfaces;
using CarStore.Shop.Domain.Models;

namespace CarStore.Shop.Domain.Interfaces;

public interface IBrandRepository : IRepository<Brand>
{
    Task<IEnumerable<Brand>> GetAll(Expression<Func<Brand, bool>>? filter = null);
    Task<Brand> GetById(Guid modelId);
    Task Add(Brand model);
    Task Update(Brand model);
}
