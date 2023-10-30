using AutoMapper;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Shop.Application.Features.Brand.CommandHandlers;
using CarStore.Shop.Application.Features.Brand.Commands;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Application.Mappings;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Models;
using Core.Test.Configurations;
using FluentAssertions;
using Moq;

namespace CarStore.Shop.Unit.Test.Brands;

public class CreateBrandCommandHandlerTests
{

    private readonly IMapper _mapper;

    public CreateBrandCommandHandlerTests()
    {
        _mapper = AutoMapperConfiguration.GetMapperConfiguration();
    }

    [Fact(DisplayName = "Create new Brand successfully")]
    [Trait("Brand Application", "Create - Create Brand Command Handler")]
    public async Task Create_Brand_ShouldBe_Successfully()
    {
        // Arrange
        var brandService = new Mock<IBrandService>();
        var commandHandler = new CreateBrandCommandHandler(_mapper, brandService.Object);
        var command = new CreateBrandCommand
        {
            Name = "Ford",
            Status = (int)TypeStatus.Active
        };

        // Act
        var result = await commandHandler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeOfType<BrandDto?>();

    }

    [Fact(DisplayName = "Create new Brand Should be null")]
    [Trait("Brand Application", "Create - Create Brand Command Handler")]
    public async Task Create_Brand_ShouldBe_Invalid()
    {
        // Arrange
        var mapper = new Mock<IMapper>();
        var brandService = new Mock<IBrandService>();
        var commandHandler = new CreateBrandCommandHandler(mapper.Object, brandService.Object);
        var command = new CreateBrandCommand
        {
            Name = "Ford",
            Status = (int)TypeStatus.Active
        };

        // Act and Assert
        var result = Assert.Throws<NotFoundException>(() => commandHandler.Handle(command, CancellationToken.None).GetAwaiter().GetResult());

    }
}