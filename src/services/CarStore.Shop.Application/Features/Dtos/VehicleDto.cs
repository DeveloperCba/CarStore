using CarStore.Shop.Application.Features.Owner.Dtos;
using CarStore.Shop.Domain.Models;

namespace CarStore.Shop.Application.Features.Brand.Dtos;

public class VehicleDto
{
    public Guid Id { get;  set; }
    public string Name { get;  set; }
    public string Renavam { get;  set; }
    public int Kilometer { get;  set; }
    public decimal Price { get;  set; }
    public TypeStatusVehicle Status { get;  set; }

    public ModelDto Model { get;  set; } = null!;

    public Guid BrandId { get;  set; }
    public BrandDto Brand { get;  set; } = null!;

    public Guid OwnerId { get;  set; }
    public OwnerDto Owner { get;  set; } = null!;

}
