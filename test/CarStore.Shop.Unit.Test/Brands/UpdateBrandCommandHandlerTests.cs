using AutoMapper;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Shop.Application.Features.Brand.CommandHandlers;
using CarStore.Shop.Application.Features.Brand.Commands;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Application.Features.Brand.Validators;
using CarStore.Shop.Application.Mappings;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Models;
using Core.Test.Configurations;
using FluentAssertions;
using FluentValidation.TestHelper;
using Moq;

namespace CarStore.Shop.Unit.Test.Brands;

public class UpdateBrandCommandHandlerTests
{

    private readonly IMapper _mapper;

    public UpdateBrandCommandHandlerTests()
    {
        _mapper = AutoMapperConfiguration.GetMapperConfiguration();
    }

    [Fact(DisplayName = "Update new Brand Validation successfully")]
    [Trait("Brand Application", "Update - Update Brand Validation")]
    public async Task Update_Brand_ValidationShouldBe_Successfully()
    {
        // Arrange
        var validator = new UpdateBrandCommandValidation();
        var command = new UpdateBrandCommand
        {
            Id = Guid.NewGuid(),
            Name = "Ford",
            Status = (int)TypeStatus.Active
        };

        // Act
        var result = await validator.TestValidateAsync(command);

        // Assert
        result.ShouldNotHaveValidationErrorFor(t => t.Id);
        result.ShouldNotHaveValidationErrorFor(t => t.Name);
        result.ShouldNotHaveValidationErrorFor(t => t.Status);

    }

    [Fact(DisplayName = "Update new Brand Validation Invalid")]
    [Trait("Brand Application", "Update - Update Brand Validation")]
    public async Task Update_Brand_ValidationShouldBe_Invalid()
    {
        // Arrange
        var validator = new UpdateBrandCommandValidation();
        var command = new UpdateBrandCommand
        {
            Id = Guid.Empty,
            Name = "",
            Status = -1
        };

        // Act
        var result = await validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(t => t.Id).WithErrorMessage("The field Id need to be provided");
        result.ShouldHaveValidationErrorFor(t => t.Name).WithErrorMessage("The field Name need to be provided");
        result.ShouldHaveValidationErrorFor(t => t.Name).WithErrorMessage("The field Name need to be between 2 e 50 characters");
        result.ShouldHaveValidationErrorFor(t => t.Status);

    }

    [Fact(DisplayName = "Update Brand successfully")]
    [Trait("Brand Application", "Create - Update Brand Command Handler")]
    public async Task Update_Brand_ShouldBe_Successfully()
    {
        // Arrange
        var brandService = new Mock<IBrandService>();
        var commandHandler = new UpdateBrandCommandHandler(_mapper, brandService.Object);
        var command = new UpdateBrandCommand
        {
            Id = Guid.NewGuid(),
            Name = "Ford",
            Status = (int)TypeStatus.Active
        };

        // Act
        var result = await commandHandler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeOfType<BrandDto?>();

    }

    [Fact(DisplayName = "Update Brand Should be null")]
    [Trait("Brand Application", "Create - Create Brand Command Handler")]
    public async Task Create_Brand_ShouldBe_Invalid()
    {
        // Arrange
        var mapper = new Mock<IMapper>();
        var brandService = new Mock<IBrandService>();
        var commandHandler = new UpdateBrandCommandHandler(mapper.Object, brandService.Object);
        var command = new UpdateBrandCommand
        {
            Id = Guid.NewGuid(),
            Name = "Ford",
            Status = (int)TypeStatus.Active
        };

        // Act and Assert
        var result = Assert.Throws<NotFoundException>(() => commandHandler.Handle(command, CancellationToken.None).GetAwaiter().GetResult());

    }
}