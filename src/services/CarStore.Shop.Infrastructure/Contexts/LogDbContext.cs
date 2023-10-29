using CarStore.Core.Datas.Interfaces;
using CarStore.Core.DomainObjects;
using CarStore.Shop.Infrastructure.Extensions;
using CarStore.Shop.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Shop.Infrastructure.Contexts;

public class LogDbContext : DbContext, IUnitOfWork
{

    public DbSet<LogError> LogErrors { get; set; }
    public DbSet<LogRequest> LogRequests { get; set; }

    public LogDbContext(DbContextOptions<LogDbContext> options) : base(options) { }
     //public LogDbContext(){ }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.ConfigureColumnTypeConvention();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conn = "Server=127.0.0.1; Database=CarShopApi; Port=15432;User Id=postgres;Password=MeuDb@123";
        optionsBuilder.UseNpgsql(conn, x => x.MigrationsHistoryTable("__LogMigration"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LogErrorMapping());
        modelBuilder.ApplyConfiguration(new LogRequestMapping());
    }

    public async Task<bool> Commit()
    {

        foreach (var entry in ChangeTracker.Entries()
                   .Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
        {

            if (entry.State == EntityState.Added)
                entry.Property("CreatedAt").CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified)
                entry.Property("CreatedAt").IsModified = false;

        }
        var success = await base.SaveChangesAsync() > 0;
        return success;

    }
}

/*
 Add-Migration AddTableLog -Context LogDbContext -OutputDir "Migrations/LogCarShop" 

 Update-Database -Context LogDbContext

*/