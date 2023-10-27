using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Core.DomainObjects;
using CarStore.Shop.Domain.Validations;
using CarStore.Shop.Domain.Models;
using FluentValidation;

namespace CarStore.Shop.Application.Features.Brand.Dtos;

public class ModelDto
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public int YearManufacturing { get; set; }
    public int YearModel { get;  set; }

    public Guid VehicleId { get; set; }
    public VehicleDto Vehicle { get; set; }
}