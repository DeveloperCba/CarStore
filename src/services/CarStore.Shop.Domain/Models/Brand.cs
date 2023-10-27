using CarStore.Core.DomainObjects;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Shop.Domain.Validations;

namespace CarStore.Shop.Domain.Models;

public  class Brand : Entity, IAggregateRoot
{
    public string Name { get; private set; } = null!;
    public TypeStatus Status { get; private set; }

    // EF Relation
    public Vehicle Vehicle { get; protected set; } = null!;
    protected Brand() { }

    public Brand(string name)
    {
        Name = name;
        if (!IsValid()) throw new DomainException("Brand invalid!");
    }


    public void Active() => Status = TypeStatus.Active;

    public void Canceled() => Status = TypeStatus.Canceled;


    public override bool IsValid()
    {
        return new BrandValidation().Validate(this).IsValid;
    }
}
