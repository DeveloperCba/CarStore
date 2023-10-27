using CarStore.Core.DomainObjects;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Shop.Domain.Validations;

namespace CarStore.Shop.Domain.Models;

public class Vehicle : Entity, IAggregateRoot
{
    public string Name { get; private set; } = null!;
    public string Renavam { get; private set; } = null!;
    public int Kilometer { get; private set; }
    public decimal Price { get; private set; }
    public TypeStatusVehicle Status { get; private set; }

    public Model Model { get; private set; } = null!;

    // EF Relation
    public Guid BrandId { get; private set; }
    public Brand Brand { get; protected set; } = null!;

    public Guid OwnerId { get; private set; }
    public Owner Owner { get; protected set; } = null!;


    // EF Relation
    protected Vehicle() { }

    public Vehicle(string name, string renavam, int kilometer, decimal price)
    {
        Name = name;
        Renavam = renavam;
        Kilometer = kilometer;
        Price = price;
        if (!IsValid()) throw new DomainException("Vehicle invalid!");
    }


    public void IsAvailable() => Status = TypeStatusVehicle.Available;

    public void IsUnavailable() => Status = TypeStatusVehicle.Unavailable;

    public void IsSold() => Status = TypeStatusVehicle.Sold;

    public void AddBrand(Brand brand)
    {
        BrandId = brand.Id;
        Brand = brand;
    }

    public void AddOwner(Owner owner)
    {
        OwnerId = owner.Id;
        Owner = owner;
    }


    public override bool IsValid()
    {
        return new VehicleValidation().Validate(this).IsValid;
    }
}
