﻿using AutoMapper;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Core.Messages;
using CarStore.Shop.Application.Features.Brand.Commands;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Domain.Interfaces;
using MediatR;

namespace CarStore.Shop.Application.Features.Brand.CommandHandlers;

public class CreateBrandCommandHandler :Command, IRequestHandler<CreateBrandCommand,BrandDto>
{
    private readonly IMapper _mapper;
    private readonly IBrandService _brandService;
    public CreateBrandCommandHandler(IMapper mapper, IBrandService brandService)
    {
        _mapper = mapper;
        _brandService = brandService;
    }
    public async Task<BrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Domain.Models.Brand>(request);
        if (model == null)
            throw new NotFoundException(nameof(Brand), request?.Name);

        await _brandService.Add(model);
        return _mapper.Map<BrandDto>(model);
    }
}
