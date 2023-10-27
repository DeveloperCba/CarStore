using CarStore.Core.DomainObjects;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Shop.Domain.Validations;

namespace CarStore.Shop.Domain.Models;

public class Address : Entity
{
    public string Street { get; private set; } = null!;
    public string Number { get; private set; } = null!;
    public string Complement { get; private set; } = null!;
    public string Neighborhood { get; private set; } = null!;
    public string ZipCode { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string State { get; private set; } = null!;
    public Guid OwnerId { get; private set; }
    public Owner Owner { get; protected set; } = null!;

    // EF Constructor
    protected Address() { }

    public Address(string street, string number, string complement, string neighborhood, string zipCode, string city, string state, Guid ownerId)
    {
        Street = street;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        ZipCode = zipCode;
        City = city;
        State = state;
        OwnerId = ownerId;
        if (!IsValid()) throw new DomainException("Address invalid!");
    }

    public override bool IsValid()
    {
        return new AddressValidation().Validate(this).IsValid;
    }
}