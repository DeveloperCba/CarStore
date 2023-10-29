using CarStore.Core.DomainObjects;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Models;
using CarStore.Shop.Domain.Validations;
using MediatR;

namespace CarStore.Shop.Domain.Services;

public class BrandService : BaseService, IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository,
                         INotify notify) : base(notify)
    {
        _brandRepository = brandRepository;
    }

    public async Task<bool> Add(Brand model)
    {
        if (!RunValidation(new BrandValidation(), model)) return false;

        if (_brandRepository.GetAll(f => f.Name == model.Name).Result.Any())
        {
            Notify("A Brand with this Description already exists.");
            return false;
        }

        await _brandRepository.Add(model);
        return await _brandRepository.UnitOfWork.Commit();
    }

    public async Task<bool> Update(Brand model)
    {
        if (!RunValidation(new BrandValidation(), model)) return false;

        var entity = await _brandRepository.GetById(model.Id);
        if (entity == null)
            throw new NotFoundException(nameof(Brand), model.Name);

        if (!model.CheckStatusIfExists((TypeStatus)model.Status))
            throw new UnprocessableException("Status does not exist");

        if (!entity.IsUpdateName(model.Name))
            throw new UnprocessableException("Cannot change name");

        if (_brandRepository.GetAll(f => f.Name == model.Name && f.Id != model.Id).Result.Any())
        {
            Notify("A Brand with this Description already exists.");
            return false;
        }

        await _brandRepository.Update(model);
        return await _brandRepository.UnitOfWork.Commit();
         
    }

   

    public void Dispose() => _brandRepository?.Dispose();

 
}
