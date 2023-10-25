using CarStore.Core.DomainObjects;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Models;
using CarStore.Shop.Domain.Validations;

namespace CarStore.Shop.Domain.Services;

public class OwnerService : BaseService, IOwnerService
{
    private readonly IOwnerRepository _ownerRepository;
    
    public OwnerService(IOwnerRepository ownerRepository,
                               INotify notify) : base(notify)
    {
        _ownerRepository = ownerRepository;
    }

    public async Task<bool> Add(Owner owner)
    {
         
        if (!RunValidation(new OwnerValidation(), owner)
            || !RunValidation(new AddressValidation(), owner.Address)) return false;

        if (_ownerRepository.GetAll(f => f.Document == owner.Document).Result.Any())
        {
            Notify("There is already an Owner with this document informed.");
            return false;
        }

        await _ownerRepository.Add(owner);
        return await _ownerRepository.UnitOfWork.Commit();
    }

    public async Task<bool> Update(Owner owner)
    {
        if (!RunValidation(new OwnerValidation(), owner)) return false;


        if (_ownerRepository.GetAll(f => f.Name != owner.Name && f.Id == owner.Id).Result.Any())
        {
            Notify("It is not possible to change the name.");
            return false;
        }

        if (_ownerRepository.GetAll(f => f.Document == owner.Document && f.Id != owner.Id).Result.Any())
        {
            Notify("There is already an Owner with this document informed.");
            return false;
        }

        await _ownerRepository.Update(owner);
        return await _ownerRepository.UnitOfWork.Commit();
    }

    public async Task UpdateAddress(Address address)
    {
        if (!RunValidation(new AddressValidation(), address)) return;

        await _ownerRepository.UpdateAddress(address);
        await _ownerRepository.UnitOfWork.Commit();
    }

    public void Dispose() => _ownerRepository?.Dispose();
}
