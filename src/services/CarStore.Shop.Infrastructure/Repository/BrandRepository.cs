using System.Linq.Expressions;
using CarStore.Core.Data;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Models;
using CarStore.Shop.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Shop.Infrastructure.Repository;

public class BrandRepository : IBrandRepository
{
    private readonly CarShopDbContext _context;

    public BrandRepository(CarShopDbContext context) => _context = context;
    public IUnitOfWork UnitOfWork => _context;

    public async Task<IEnumerable<Brand>> GetAll(Expression<Func<Brand, bool>>? filter = null)
    {
        if (filter != null)
           return  await _context.Brands.Where(filter).ToListAsync();

        return await _context.Brands.ToListAsync();
    }

    public async Task<Brand> GetById(Guid modelId)
    {
        return await _context.Brands.FindAsync(modelId);
    }

    public async Task Add(Brand model)
    {
        await _context.Brands.AddAsync(model);
    }

    public async Task Update(Brand model)
    {
       await Task.Run(()=>  _context.Brands.Update(model));
    }

    public void Dispose() => _context.Dispose();
}
