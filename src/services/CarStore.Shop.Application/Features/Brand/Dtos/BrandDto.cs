using CarStore.Shop.Domain.Models;

namespace CarStore.Shop.Application.Features.Brand.Dtos;

public  class BrandDto  
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TypeStatus Status { get; set; }
    
    public VehicleDto Vehicle { get; set; }

}