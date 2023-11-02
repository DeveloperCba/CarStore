using CarStore.Shop.Application.Features.Brand.Events;
using MediatR;

namespace CarStore.Shop.Application.Features.Brand.EventHandlers;

public class CreateBrandEventHandler : INotificationHandler<CreateBrandEvent>
{


    public async Task Handle(CreateBrandEvent notification, CancellationToken cancellationToken)
    {
       //Send RabbitMq
       Console.WriteLine("OK");
    }
}