using CarStore.Core.Data;
using CarStore.Core.DomainObjects;
using CarStore.Core.Mediator;
using CarStore.Core.Messages;
using CarStore.Shop.Domain.Models;
using CarStore.Shop.Infrastructure.Extensions;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Shop.Infrastructure.Contexts;

public class CarShopDbContext : DbContext, IUnitOfWork
{
    private readonly IMediatorHandler _mediator;

    //public CarShopDbContext(){}
    public CarShopDbContext(DbContextOptions<CarShopDbContext> options,
        IMediatorHandler mediator) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;

        _mediator = mediator;
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Model> Models { get; set; }


    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.ConfigureColumnTypeConvention();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //var conn = "Server=pgsql.oficinadev.kinghost.net; Database=oficinadev; Port=5432;User Id=oficinadev;Password=Estadao101322";
        //optionsBuilder.UseNpgsql(conn, x => x.MigrationsHistoryTable("_AuthMigration"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.Ignore<Event>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarShopDbContext).Assembly);
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
        if (success)
            await _mediator.PublishEvent(this);

        return success;

    }
}
