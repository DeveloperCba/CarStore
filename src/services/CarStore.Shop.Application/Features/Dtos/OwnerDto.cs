using CarStore.Shop.Domain.Models;
using CarStore.Shop.Domain.Validations.Documents;

namespace CarStore.Shop.Application.Features.Brand.Dtos;

public class OwnerDto  
{
    public Guid Id { get; set; }
    public string Name { get;  set; }
    public string Document { get;  set; }
    public TypeStatus Status { get;  set; }
    public OwnerType OwnerType { get;  set; }

    public Guid AddressId { get; private set; }
    public AddressDto Address { get; private set; } 

    public Email Email { get; private set; }
    public VehicleDto Vehicle { get;  set; } 
   
}