using CarStore.Core.Datas.Interfaces;
using CarStore.Core.DomainObjects;
using CarStore.Shop.Infrastructure.Contexts;

namespace CarStore.Shop.Infrastructure.Repository;

public class LogRequestRepository :   ILogRequestRepository
{
    private readonly LogDbContext _context;
    public LogRequestRepository(LogDbContext context) 
    {
        _context = context;
    }
    public IUnitOfWork UnitOfWork => _context;

    public async Task Add(LogRequest entity)
    {
        await _context.LogRequests.AddAsync(entity);
    }

    public async Task Update(LogRequest entity)
    {
        await Task.Run(() => _context.LogRequests.Update(entity));
    }
}