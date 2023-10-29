using MediatR;

namespace CarStore.Shop.Application.Features.Brand.Commands;

public class DeleteBrandCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}