using CarStore.Shop.Application.Features.Brand.Dtos;
using MediatR;

namespace CarStore.Shop.Application.Features.Brand.Queries;

public class GetBrandByIdQuery : IRequest<BrandDto>
{
    public string Id { get; set; }
}