using CarStore.Core.Messages;

namespace CarStore.Shop.Application.Features.Brand.Events;

public class CreateBrandEvent : Event
{
    public Guid Id { get; private set; }
    public string Name { get; set; }

    public CreateBrandEvent(Guid id)
    {
        Id = id;
        AggregateId = id;
    }
}