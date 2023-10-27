using CarStore.Core.DomainObjects;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Shop.Domain.Validations;
using CarStore.Shop.Domain.Validations.Documents;

namespace CarStore.Shop.Domain.Models;

public class Owner : Entity, IAggregateRoot
{
    public string Name { get; private set; } = null!;
    public string  Document { get; private set; } = null!;
    public TypeStatus Status { get; private set; }
    public OwnerType OwnerType { get; private set; }

    public Email Email { get; private set; } = null!;

    // EF Relation
    public Vehicle Vehicle { get; protected set; } = null!;
    public Address Address { get; protected set; } = null!;

    protected Owner() { }

    public Owner(string name, string document)
    {
        Name = name;
        Document = document;
        if (!IsValid()) throw new DomainException("Owner invalid!");
    }

    public void Active() => Status = TypeStatus.Active;

    public void Canceled() => Status = TypeStatus.Canceled;

    public void ChangeEmail(string email) => Email = new Email(email);


    public override bool IsValid()
    {
        return new OwnerValidation().Validate(this).IsValid;
    }
}

