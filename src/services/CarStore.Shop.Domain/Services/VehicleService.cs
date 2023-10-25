using CarStore.Core.DomainObjects;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Models;
using CarStore.Shop.Domain.Validations;

namespace CarStore.Shop.Domain.Services;

public class VehicleService : BaseService, IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleService(IVehicleRepository vehicleRepository,
                          INotify notify) : base(notify)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<bool> Add(Vehicle vehicle)
    {
        if (!RunValidation(new VehicleValidation(), vehicle)) return false;

        if (!RunValidation(new VehicleValidation(), vehicle)
            || !RunValidation(new ModelValidation(), vehicle.Model)) return false;

        if (_vehicleRepository.GetAll(f => f.Renavam == vehicle.Renavam).Result.Any())
        {
            Notify("There is already a Renavam with this number.");
            return false;
        }
     
        await _vehicleRepository.Add(vehicle);
        return await _vehicleRepository.UnitOfWork.Commit();
    }

    public async Task<bool> Update(Vehicle vehicle)
    {
        if (!RunValidation(new VehicleValidation(), vehicle)) return false;

        if (_vehicleRepository.GetAll(f => f.Name != vehicle.Name && f.Id == vehicle.Id).Result.Any())
        {
            Notify("It is not possible to change the name.");
            return false;
        }

        if (_vehicleRepository.GetAll(f => f.Renavam == vehicle.Renavam && f.Id != vehicle.Id).Result.Any())
        {
            Notify("There is already a Renavam with this number.");
            return false;
        }

        if (_vehicleRepository.CheckStatus(vehicle.Id, vehicle.Status).Result)
        {
            Notify("Cannot change status to available.");
            return false;
        }

        await _vehicleRepository.Update(vehicle);
        return await _vehicleRepository.UnitOfWork.Commit();
    }

    public async Task UpdateModel(Model model)
    {
        if (!RunValidation(new ModelValidation(), model)) return;

        await _vehicleRepository.UpdateModel(model);
        await _vehicleRepository.UnitOfWork.Commit();
    }

    public void Dispose() => _vehicleRepository?.Dispose();
}
