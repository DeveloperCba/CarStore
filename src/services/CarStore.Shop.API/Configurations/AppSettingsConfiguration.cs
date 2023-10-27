using CarStore.Core.Comunications;

namespace CarStore.Shop.API.Configurations;

public static class AppSettingsConfiguration
{

    public static IServiceCollection AddConfigurationParameter(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {

        var jwtSettingsSection = configuration.GetSection(nameof(JwtSettings));
        services.Configure<JwtSettings>(jwtSettingsSection);

        return services;
           
    }
}