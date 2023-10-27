using CarStore.Shop.Infrastructure.Contexts;
using CarStore.WebAPI.Core.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Shop.API.Configurations;

public static class IdentityConfiguration
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        var conn = configuration.GetConnectionString("PostgresConnection");
        AddDbAplicationUserIdentity(services, conn);
        AddDbLog(services, conn);

        //services.AddDefaultIdentity<ApplicationUser>()
        //    .AddRoles<ApplicationRole>()
        //    .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
        //    .AddErrorDescriber<IdentityMessagePortugues>()
        //    .AddDefaultTokenProviders();

        // JWT
        services.AddJwtConfiguration(configuration);
        return services;
    }

     

    private static void AddDbAplicationUserIdentity(IServiceCollection services, string conn)
    {
        
        var migrationName = "__CarShopApiMigration";
        services.AddDbContext<CarShopDbContext>(options =>
            options.UseNpgsql(conn, x => x.MigrationsHistoryTable(migrationName)));
    }


    private static void AddDbLog(IServiceCollection services, string conn)
    {
        var migrationName = "__LogMigration";
        services.AddDbContext<LogDbContext>(options =>
            options.UseNpgsql(conn, x => x.MigrationsHistoryTable(migrationName)));
    }
}