using CarStore.Core.DomainObjects;
using CarStore.Core.Mediator;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Shop.Infrastructure.Extensions;

public static class MediatorExtension
{
    public static async Task PublishEvent<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.GetNotifications() != null && x.Entity.GetNotifications().Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.GetNotifications())
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearEvent());

        var tasks = domainEvents
            .Select(async (domainEvent) =>
            {
                await mediator.Publish(domainEvent);
            });
        await Task.WhenAll(tasks);
    }
}