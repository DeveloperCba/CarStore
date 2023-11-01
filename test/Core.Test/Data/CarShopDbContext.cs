using CarStore.Core.Datas.Interfaces;
using CarStore.Core.Mediator;
using CarStore.Core.Messages;
using CarStore.Shop.Domain.Models;
using CarStore.Shop.Infrastructure.Contexts;
using CarStore.Shop.Infrastructure.Extensions;
using CarStore.Shop.Infrastructure.Mappings;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Shop.Unit.Test.Data
{
    public class CarShopTextDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediator;

        //public CarShopDbContext(){}
        public CarShopTextDbContext(DbContextOptions<CarShopTextDbContext> options,
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
      
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new BrandMapping());
            modelBuilder.ApplyConfiguration(new ModelMapping());
            modelBuilder.ApplyConfiguration(new OwnerMapping());
            modelBuilder.ApplyConfiguration(new VehicleMapping());
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
            await base.SaveChangesAsync();
   

            return true;

        }
    }
}


/*
    Add-Migration AddTableShop -Context CarShopDbContext -OutputDir "Migrations/CarShop" 
    Update-Database -Context CarShopDbContext
*/