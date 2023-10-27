using System.Linq.Expressions;
using CarStore.Core.Datas.Interfaces;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Models;
using CarStore.Shop.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Shop.Infrastructure.Repository;

public class VehicleRepository : IVehicleRepository
{
    private readonly CarShopDbContext _context;

    public VehicleRepository(CarShopDbContext context) => _context = context;
    public IUnitOfWork UnitOfWork => _context;

    public async Task<IEnumerable<Vehicle>> GetAll(Expression<Func<Vehicle, bool>> filter = null)
    {
        if (filter != null)
            return await _context.Vehicles.Include(x=>x.Model).Where(filter).ToListAsync();

        return await _context.Vehicles.ToListAsync();
    }

    public async Task<Vehicle> GetById(Guid modelId)
    {
        return await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == modelId);
    }
    public async  Task  Update(Vehicle model)
    {
       await Task.Run((()=>_context.Vehicles.Update(model)));
    }
    public async Task   Add(Vehicle model)
    {
        await _context.Vehicles.AddAsync(model);
    }

    public async Task<Model> GetModelById(Guid id)
    {
        return await _context.Models.FirstOrDefaultAsync(x => x.VehicleId == id);
    }

    public async Task<Owner> GetOwnerById(Guid id)
    {
        return await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateModel(Model model)
    {
        await Task.Run(() => _context.Models.Update(model));
    }

    public async Task<bool> CheckStatus(Guid modelId, TypeStatusVehicle status)
    {
        return await _context.Vehicles.Where(x => x.Id == modelId && x.Status == 0).AnyAsync();
    }

    public async Task  UpdateBrand(Brand model)
    {
        await Task.Run(() => _context.Brands.Update(model));
    }

    public async Task  UpdateOwner(Owner model)
    {
        await Task.Run(() => _context.Owners.Update(model));
    }

    public void Dispose() => _context.Dispose();
}