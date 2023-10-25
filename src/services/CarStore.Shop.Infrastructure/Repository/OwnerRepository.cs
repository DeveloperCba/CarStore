using System.Linq.Expressions;
using CarStore.Core.Data;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Models;
using CarStore.Shop.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Shop.Infrastructure.Repository;

public class OwnerRepository : IOwnerRepository
{
    private readonly CarShopDbContext _context;

    public OwnerRepository(CarShopDbContext context) => _context = context;
    public IUnitOfWork UnitOfWork => _context;

    public async Task<IEnumerable<Owner>> GetAll(Expression<Func<Owner, bool>> filter = null)
    {
        var query = _context.Owners.Include(x=> x.Address);

        if (filter != null)
            return await _context.Owners.Where(filter).Include(x => x.Address).ToListAsync();

        return await _context.Owners.Include(x => x.Address).ToListAsync();
    }

    public async Task<Owner> GetById(Guid modelId)
    {
        return await _context.Owners.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == modelId);
    }
    public async Task Update(Owner model)
    {
        await Task.Run(() => _context.Owners.Update(model));
    }
    public async Task Add(Owner model)
    {
        await Task.Run(() => _context.Owners.Update(model));
    }

    public async Task UpdateAddress(Address model)
    {
        await Task.Run(() => _context.Addresses.Update(model));
    }

    public async Task<Address> GetAddressById(Guid id)
    {
        return await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
    }

 
    public void Dispose() => _context.Dispose();
}
