using CarStore.Core.Datas.Interfaces;
using CarStore.Core.DomainObjects;
using CarStore.Core.Mediator;
using CarStore.Shop.Application;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Services;
using CarStore.Shop.Infrastructure.Contexts;
using CarStore.Shop.Infrastructure.Repository;
using CarStore.WebAPI.Core.Identities;
using CarStore.WebAPI.Core.Middlewares;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CarStore.Shop.API.Configurations;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddScoped<INotify, Notify>();
        services.AddScoped<IAspNetUser, AspNetUser>();
        services.AddScoped<IMediatorHandler, MediatorHandler>();
 
        services.AddUnhandledExceptionMiddlewareServices();
        services.AddValidationMiddlewareServices();

        services.AddIdentityConfiguration(configuration);

        services.AddApplicationServices();

        services.AddHttpClientService()
            .AddDependencyInjectionService()
            ;
        DependencyInjectionRepository(services);


        return services;
    }
 

    private static void DependencyInjectionRepository(IServiceCollection services)
    {
        services.AddScoped<ILogErrorRepository,LogErrorRepository>();
        services.AddScoped<ILogRequestRepository, LogRequestRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
 
    }
    private static IServiceCollection AddHttpClientService(this IServiceCollection services)
    {
        services.AddScoped<IBrandService, BrandService>();
        services.AddHttpClient();
        return services;
    }

    private static IServiceCollection AddDependencyInjectionService(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddUnhandledExceptionMiddlewareServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionMiddleware<,>));
        return services;
    }

    public static IServiceCollection AddValidationMiddlewareServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationMiddleware<,>));
        return services;
    }

    public static IServiceCollection AddAuthorizationBehaviorMiddlewareServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        return services;
    }


    public static IApplicationBuilder UseRequestResponseLoggingMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<RequestResponseLoggingMiddleware>();
    }

    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionMiddleware>();
    }

  
}