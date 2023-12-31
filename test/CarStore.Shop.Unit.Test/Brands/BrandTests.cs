﻿using CarStore.Core.DomainObjects.Exceptions;
using CarStore.Shop.Domain.Models;
using CarStore.Shop.Unit.Test.Brands.Configurations;
using FluentAssertions;

namespace CarStore.Shop.Unit.Test.Brands;

[Collection(nameof(BrandTestsCollection))]

public class BrandTests
{
    private readonly BrandTestsFixture _brandTestsFixture;

    public BrandTests(BrandTestsFixture brandTestsFixture)
    {
        _brandTestsFixture = brandTestsFixture;
    }

    [Fact(DisplayName = "Valid brand")]
    [Trait("Brand","Validation")]
    public void Brand_ShouldBeValid_ReturnTrue()
    {
        // Arrange
        var entity = _brandTestsFixture.GetBrand();

        // Act
        var result = entity.IsValid();

        // Assert
        result.Should().BeTrue();

    }

    [Fact(DisplayName = "Invalid brand")]
    [Trait("Brand", "Validation")]
    public void Brand_ShouldBeInvalid_ReturnTrue()
    {
        // Arrange & Act & Assert
        Assert.Throws<DomainException>(() => new Brand(string.Empty));
    }

    [Fact(DisplayName = "Check Status True")]
    [Trait("Brand", "Validation")]
    public void  Status_ShouldBeValid_ReturnTrue()
    {
        // Arrange
        var entity = _brandTestsFixture.GetBrand(); 
        var status = TypeStatus.Active;

        // Act
        var result = entity.CheckStatusIfExists(status);

        // Assert
        result.Should().BeTrue();

    }

    [Fact(DisplayName = "Check Status False")]
    [Trait("Brand", "Validation")]
    public void Status_ShouldBeInvalid_ReturnFalse()
    {
        // Arrange
        var entity = _brandTestsFixture.GetBrand();
        var status = (TypeStatus)5;

        // Act
        var result = entity.CheckStatusIfExists(status);

        // Assert
        result.Should().BeFalse();

    }

    [Fact(DisplayName = "Check Name Different")]
    [Trait("Brand", "Validation")]
    public void Name_ShouldBeDifferent_ReturnFalse()
    {
        // Arrange
        var entity = _brandTestsFixture.GetBrand();

        // Act
        var result = entity.IsUpdateName("Toyota");

        // Assert
        result.Should().BeFalse();

    }

    [Fact(DisplayName = "Check Name Equal")]
    [Trait("Brand", "Validation")]
    public void Name_ShouldBeDifferent_ReturnTrue()
    {
        // Arrange
        var entity = _brandTestsFixture.GetBrand();

        // Act
        var result = entity.IsUpdateName(entity.Name);

        // Assert
        result.Should().BeTrue();
    }


    [Fact(DisplayName = "Check exchange status")]
    [Trait("Brand", "Validation")]
    public void Status_CheckExchangeStatus_ReturnNewStatus()
    {
        // Arrange
        var entity = _brandTestsFixture.GetBrand();

        // Act
        entity.SetStatus(TypeStatus.Canceled);

        // Assert
        entity.Status.Should().Be(TypeStatus.Canceled);
    }
}