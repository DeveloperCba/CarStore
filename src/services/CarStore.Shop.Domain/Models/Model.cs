using CarStore.Core.DomainObjects;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Shop.Domain.Validations;

namespace CarStore.Shop.Domain.Models;

public class Model : Entity
{
    public string Description { get; private set; } = null!;
    public int YearManufacturing { get; private set; }
    public int YearModel { get; private set; }

    public Guid VehicleId { get; private set; }

    // EF Relation
    public Vehicle Vehicle { get; protected set; } = null!;

    // EF Constructor
    protected Model() { }

    public Model(string description, int yearManufacturing, int yearModel, Guid vehicleId)
    {
        Description = description;
        YearManufacturing = yearManufacturing;
        YearModel = yearModel;
        VehicleId = vehicleId;

        if (!IsValid()) throw new DomainException("Model invalid!");
    }


    public override bool IsValid()
    {
        return new ModelValidation().Validate(this).IsValid;
    }
}