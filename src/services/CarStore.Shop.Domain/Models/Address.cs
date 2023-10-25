using CarStore.Core.DomainObjects;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Shop.Domain.Validations;

namespace CarStore.Shop.Domain.Models;

public class Address : Entity
{
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string Neighborhood { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public Guid OwnerId { get; private set; }

    // EF Relation
    public Owner Owner { get; protected set; }

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