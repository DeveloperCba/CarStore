using AutoMapper;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Shop.Application.Features.Brand.CommandHandlers;
using CarStore.Shop.Application.Features.Brand.Commands;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Models;
using CarStore.Shop.Infrastructure.Contexts;
using Core.Test.Configurations;
using FluentAssertions;
using Moq;

namespace CarStore.Shop.Unit.Test.Brands;

public class UpdateStatusBrandCommandHandlerTests
{
    private readonly IMapper _mapper;

    public UpdateStatusBrandCommandHandlerTests()
    {
        _mapper = AutoMapperConfiguration.GetMapperConfiguration();
    }

    [Fact(DisplayName = "Update Status Brand Should be null")]
    [Trait("Brand Application", "Update - Update Status Brand Command Handler")]
    public async Task UpdataStatus_Brand_ShouldBe_Successfufly()
    {
        // Arrange
        var id = Guid.Parse("43689689-5dce-4d75-b227-e6ab02b1baa4");
        var context = DbContextFactory.CreateCarShopDbContext($"{nameof(CarShopDbContext)}-{Guid.NewGuid()}");
        var brandRepository = new Mock<IBrandRepository>();
        brandRepository.Setup(x =>   x.GetById(id)).ReturnsAsync(new Brand("Ford"));
        brandRepository.Setup(x => x.UnitOfWork).Returns(context);

        var commandHandler = new UpdateStatusBrandCommandHandler(_mapper, brandRepository.Object);
        var command = new UpdateStatusBrandCommand
        {
            Id = id,
            Status = (int)TypeStatus.Canceled
        };

        // Act
        var result = await commandHandler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeOfType<BrandDto>();
    }


    [Fact(DisplayName = "Update Status Brand Should be null")]
    [Trait("Brand Application", "Update - Update Status Brand Command Handler")]
    public async Task UpdateStatus_Brand_ShouldBe_Invalid()
    {
        // Arrange
        var id = Guid.Parse("43689689-5dce-4d75-b227-e6ab02b1baa4");
        var context = DbContextFactory.CreateCarShopDbContext($"{nameof(CarShopDbContext)}-{Guid.NewGuid()}");
        var brandRepository = new Mock<IBrandRepository>();
        brandRepository.Setup(x => x.GetById(id)).ReturnsAsync(new Brand("Ford"));
        brandRepository.Setup(x => x.UnitOfWork).Returns(context);

        var commandHandler = new UpdateStatusBrandCommandHandler(_mapper, brandRepository.Object);
        var command = new UpdateStatusBrandCommand
        {
            Id = Guid.NewGuid(),
            Status = (int)TypeStatus.Active
        };

        // Act and Assert
        var result = await Assert.ThrowsAsync<NotFoundException>(() => commandHandler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "Update Status Brand Should be invalid")]
    [Trait("Brand Application", "Update - Update Status Brand Command Handler")]
    public async Task UpdateStatus_Brand_ShouldBe_StatusInvalid()
    {
        // Arrange
        var id = Guid.Parse("43689689-5dce-4d75-b227-e6ab02b1baa4");
        var context = DbContextFactory.CreateCarShopDbContext($"{nameof(CarShopDbContext)}-{Guid.NewGuid()}");
        var brandRepository = new Mock<IBrandRepository>();
        brandRepository.Setup(x => x.GetById(id)).ReturnsAsync(new Brand("Ford"));
        brandRepository.Setup(x => x.UnitOfWork).Returns(context);

        var commandHandler = new UpdateStatusBrandCommandHandler(_mapper, brandRepository.Object);
        var command = new UpdateStatusBrandCommand
        {
            Id = id,
            Status = (int)10
        };

        // Act  
        var result = await (Assert.ThrowsAsync<UnprocessableException>(() => commandHandler.Handle(command, CancellationToken.None)));

        // Assert
        result.Message.Should().Contain("Status does not exist");
    }


    [Fact(DisplayName = "Update Status Brand Should be invalid")]
    [Trait("Brand Application", "Update - Update Status Brand Command Handler")]
    public async Task UpdateStatusEqual_Brand_ShouldBe_StatusInvalid()
    {
        // Arrange
        var id = Guid.Parse("43689689-5dce-4d75-b227-e6ab02b1baa4");
        var context = DbContextFactory.CreateCarShopDbContext($"{nameof(CarShopDbContext)}-{Guid.NewGuid()}");
        var brandRepository = new Mock<IBrandRepository>();
        brandRepository.Setup(x => x.GetById(id)).ReturnsAsync(new Brand("Ford"));
        brandRepository.Setup(x => x.UnitOfWork).Returns(context);

        var commandHandler = new UpdateStatusBrandCommandHandler(_mapper, brandRepository.Object);
        var command = new UpdateStatusBrandCommand
        {
            Id = id,
            Status = (int)TypeStatus.Active
        };

        // Act  
        var result = await (Assert.ThrowsAsync<UnprocessableException>(() => commandHandler.Handle(command, CancellationToken.None)));
         
        // Assert
         result.Message.Should().Contain("Enter a different status as this is the current status");
    }
}