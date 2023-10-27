using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CarStore.Shop.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(src => src.RegisterServicesFromAssembly(assembly: Assembly.GetExecutingAssembly()));

        return services;
    }
}