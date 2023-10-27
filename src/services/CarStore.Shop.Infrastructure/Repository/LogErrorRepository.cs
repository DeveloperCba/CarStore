using CarStore.Core.Datas.Interfaces;
using CarStore.Core.DomainObjects;
using CarStore.Shop.Infrastructure.Contexts;

namespace CarStore.Shop.Infrastructure.Repository;

public class LogErrorRepository :  ILogErrorRepository
{
    private readonly LogDbContext _context;
    public LogErrorRepository(LogDbContext context) 
    {
        _context = context;
    }
    public IUnitOfWork UnitOfWork => _context;

    public async Task Add(LogError entity)
    {
      await   _context.LogErrors.AddAsync(entity);
    }

    public async Task Update(LogError entity)
    {
        await Task.Run(() => _context.LogErrors.Update(entity));
    }
}