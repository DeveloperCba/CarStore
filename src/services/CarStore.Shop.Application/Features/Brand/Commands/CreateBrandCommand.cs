﻿using CarStore.Shop.Application.Features.Brand.Dtos;
using MediatR;

namespace CarStore.Shop.Application.Features.Brand.Commands;

public class CreateBrandCommand : IRequest<BrandDto>
{
    public string Name { get; set; }
    public int Status { get; set; }
}