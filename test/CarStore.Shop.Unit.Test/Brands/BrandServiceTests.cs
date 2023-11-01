using CarStore.Core.Datas.Interfaces;
using CarStore.Core.DomainObjects;
using CarStore.Shop.Application.Features.Brand.CommandHandlers;
using CarStore.Shop.Application.Features.Brand.Commands;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Models;
using CarStore.Shop.Domain.Services;
using CarStore.Shop.Infrastructure.Contexts;
using Core.Test.Configurations;
using FluentAssertions;
using Moq;

namespace CarStore.Shop.Unit.Test.Brands;

public class BrandServiceTests
{
    private readonly Mock<IBrandRepository> _brandRepository;
    private readonly Mock<IBrandService> _brandService;
    private readonly Mock<INotify> _notify;
    private  Mock<IUnitOfWork> _unitOfWork;

    public BrandServiceTests()
    {
        _brandRepository = new Mock<IBrandRepository>();
        _brandService = new Mock<IBrandService>();
        _notify = new Mock<INotify>();
        _unitOfWork = new Mock<IUnitOfWork>();
    }

    [Fact(DisplayName = "Create new Brand successfully")]
    [Trait("Brand Service", "Create - Create Brand")]
    public async Task Create_Brand_ShouldBe_Successfully()
    {
        // Arrange
        var entity = new Brand("Ford");
        entity.Active();

        var brandService = new BrandService(_brandRepository.Object, _notify.Object);
        var context = DbContextFactory.CreateCarShopDbContext($"{nameof(CarShopDbContext)}-{Guid.NewGuid()}");
        _brandRepository.Setup(x=> x.UnitOfWork).Returns(context);

        // Act
        var result = await brandService.Add(entity);

        // Assert
        result.Should().Be(true);

    }

    [Fact(DisplayName = "Create new Brand invalid")]
    [Trait("Brand Service", "Create - Create Brand")]
    public async Task Create_Brand_ShouldBe_Invalid()
    {
        // Arrange
        var entity = new Brand("Ford");
        entity.Active();

        entity.SetName(string.Empty);
        var brandService = new BrandService(_brandRepository.Object, _notify.Object);
        var context = DbContextFactory.CreateCarShopDbContext($"{nameof(CarShopDbContext)}-{Guid.NewGuid()}");
        _brandRepository.Setup(x => x.UnitOfWork).Returns(context);

        // Act
        var result = await brandService.Add(entity);

        // Assert
        result.Should().Be(false);

    }
}