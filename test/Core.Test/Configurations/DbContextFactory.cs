using CarStore.Core.Datas.Interfaces;
using CarStore.Core.Mediator;
using CarStore.Shop.Infrastructure.Contexts;
using CarStore.Shop.Unit.Test.Data;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Core.Test.Configurations;

public class DbContextFactory
{
    public static TDbContext? CreateDbContext<TDbContext>(string databaseName) where TDbContext : DbContext
    {
        var options = new DbContextOptionsBuilder<TDbContext>()
            .UseInMemoryDatabase(databaseName: databaseName)
            .Options;

        return (TDbContext)Activator.CreateInstance(typeof(TDbContext), options);
    }

    public static CarShopTextDbContext? CreateCarShopDbContext(string databaseName)
    {
        var meditor = new Mock<IMediatorHandler>();
        var options = new DbContextOptionsBuilder<CarShopTextDbContext>()
            .UseInMemoryDatabase(databaseName: databaseName)
            .Options;

        var dbContextFake = new CarShopTextDbContext(options, meditor.Object);
        dbContextFake.Database.EnsureDeleted();

        return dbContextFake;
    }
}