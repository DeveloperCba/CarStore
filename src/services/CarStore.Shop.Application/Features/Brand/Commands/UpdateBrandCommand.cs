using CarStore.Shop.Application.Features.Brand.Dtos;
using MediatR;

namespace CarStore.Shop.Application.Features.Brand.Commands;

public class UpdateBrandCommand : IRequest<BrandDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Status { get; set; }
}