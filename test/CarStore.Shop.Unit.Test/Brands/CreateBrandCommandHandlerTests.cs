using AutoMapper;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Shop.Application.Features.Brand.CommandHandlers;
using CarStore.Shop.Application.Features.Brand.Commands;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Application.Features.Brand.Validators;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Models;
using Core.Test.Configurations;
using FluentAssertions;
using FluentValidation.TestHelper;
using MediatR;
using Moq;

namespace CarStore.Shop.Unit.Test.Brands;

public class CreateBrandCommandHandlerTests
{
    private readonly IMapper _mapper;
    public CreateBrandCommandHandlerTests()
    {
        _mapper = AutoMapperConfiguration.GetMapperConfiguration();
    }

    [Fact(DisplayName = "Create new Brand Validation successfully")]
    [Trait("Brand Application", "Create - Create Brand Validation")]
    public async Task Create_Brand_ValidationShouldBe_Successfully()
    {
        // Arrange
        var validator = new CreateBrandCommandValidation();
        var command = new CreateBrandCommand
        {
            Name = "Ford",
            Status = (int)TypeStatus.Active
        };

        // Act
        var result = await validator.TestValidateAsync(command);

        // Assert
        result.ShouldNotHaveValidationErrorFor(t => t.Name);
        result.ShouldNotHaveValidationErrorFor(t => t.Status);

    }

    [Fact(DisplayName = "Create new Brand Validation Invalid")]
    [Trait("Brand Application", "Create - Create Brand Validation")]
    public async Task Create_Brand_ValidationShouldBe_Invalid()
    {
        // Arrange
        var validator = new CreateBrandCommandValidation();
        var command = new CreateBrandCommand
        {
            Name = "",
            Status =  -1
        };

        // Act
        var result = await validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(t => t.Name).WithErrorMessage("The field Name needs to be provided");
        result.ShouldHaveValidationErrorFor(t => t.Name).WithErrorMessage("The field Name need to be between 2 e 50 characters");
        result.ShouldHaveValidationErrorFor(t => t.Status);

    }

    [Fact(DisplayName = "Create new Brand successfully")]
    [Trait("Brand Application", "Create - Create Brand Command Handler")]
    public async Task Create_Brand_ShouldBe_Successfully()
    {
        // Arrange
        var mediator = new Mock<IMediator>();
        var brandService = new Mock<IBrandService>();
        var commandHandler = new CreateBrandCommandHandler(_mapper, brandService.Object, mediator.Object);
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
        var mediator = new Mock<IMediator>();
        var mapper = new Mock<IMapper>();
        var brandService = new Mock<IBrandService>();
        var commandHandler = new CreateBrandCommandHandler(mapper.Object, brandService.Object, mediator.Object);
        var command = new CreateBrandCommand
        {
            Name = "Ford",
            Status = (int)TypeStatus.Active
        };

        // Act and Assert
        var result = await Assert.ThrowsAsync<NotFoundException>(() => commandHandler.Handle(command, CancellationToken.None));

    }
}