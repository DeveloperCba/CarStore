using AutoMapper;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Core.Messages;
using CarStore.Shop.Application.Features.Brand.Commands;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Models;
using MediatR;

namespace CarStore.Shop.Application.Features.Brand.CommandHandlers;

public class UpdateStatusBrandCommandHandler : Command, IRequestHandler<UpdateStatusBrandCommand, BrandDto>
{
    private readonly IMapper _mapper;
    private readonly IBrandRepository _brandRepository;
    public UpdateStatusBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
    {
        _mapper = mapper;
        _brandRepository = brandRepository;
    }
    public async Task<BrandDto> Handle(UpdateStatusBrandCommand request, CancellationToken cancellationToken)
    {
        var model = await _brandRepository.GetById(request.Id);
        if (model == null)
            throw new NotFoundException(nameof(Brand), "");

        if (!model.CheckStatusIfExists((TypeStatus)request.Status))
            throw new UnprocessableException("Status does not exist");

        if (model.CheckStatusEqual((TypeStatus)request.Status))
            throw new UnprocessableException("Enter a different status as this is the current status");

        model.SetStatus((TypeStatus)request.Status);

        await _brandRepository.Update(model);
        await _brandRepository.UnitOfWork.Commit();

        return _mapper.Map<BrandDto>(model);
    }

}