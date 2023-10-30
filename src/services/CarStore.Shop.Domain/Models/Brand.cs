using System.Reflection.Metadata.Ecma335;
using CarStore.Core.DomainObjects;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Shop.Domain.Validations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarStore.Shop.Domain.Models;

public class Brand : Entity, IAggregateRoot
{
    public string Name { get; private set; } = null!;
    public TypeStatus Status { get; private set; }

    // EF Relation
    public Vehicle Vehicle { get; protected set; } = null!;
    protected Brand() { }

    public Brand(string name)
    {
        Name = name;
        Active();
        if (!IsValid()) throw new DomainException("Brand invalid!");
    }


    public void Active() => Status = TypeStatus.Active;

    public void Canceled() => Status = TypeStatus.Canceled;

    public bool IsUpdateName(string name)
    {
        return Name.ToUpper() == name.ToUpper();
    }

    public void SetStatus(TypeStatus status)
    {
        switch (status)
        {
            case TypeStatus.Active:
                Active();
                break;
            case TypeStatus.Canceled:
                Canceled();
                break;
        }
    }

    public bool CheckStatusIfExists(TypeStatus status)
    {
        if (!Enum.IsDefined(typeof(TypeStatus), status))
            return false;

        return true;
    }

    public bool CheckStatusEqual(TypeStatus status)
    {
        if (Status != status)
            return false;

        return true;
    }

    public override bool IsValid()
    {
        return new BrandValidation().Validate(this).IsValid;
    }
}
