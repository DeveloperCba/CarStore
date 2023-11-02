using AutoMapper;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Application.Features.Brand.Queries;
using CarStore.Shop.Application.Features.Brand.QueriesHandlers;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Unit.Test.Brands.Configurations;
using Core.Test.Configurations;
using FluentAssertions;
using Moq;

namespace CarStore.Shop.Unit.Test.Brands;

[Collection(nameof(BrandTestsCollection))]

public class GetBrandByIdQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly BrandTestsFixture _brandTestsFixture;

    public GetBrandByIdQueryHandlerTests(BrandTestsFixture brandTestsFixture)
    {
        _brandTestsFixture = brandTestsFixture;
        _mapper = AutoMapperConfiguration.GetMapperConfiguration();
    }

    [Fact(DisplayName = "GetById Brand Should be valid")]
    [Trait("Brand Application", "GetById - GetById Brand Command Handler")]
    public async Task GetById_ShouldBe_Successufly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entity = _brandTestsFixture.GetBrand(); 
        var brandRepository = new Mock<IBrandRepository>();
        brandRepository.Setup(b => b.GetById(id)).ReturnsAsync(entity);
        var query = new GetBrandByIdQuery { Id = id.ToString() };
        var queryHandler = new GetBrandByIdQueryHandler(_mapper, brandRepository.Object);

        // Act
        var result = await queryHandler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeOfType<BrandDto>();
        result.Should().NotBeNull();
    }


    [Fact(DisplayName = "GetById Brand Should be invalid")]
    [Trait("Brand Application", "GetById - GetById Brand Command Handler")]
    public async Task GetById_ShouldBe_Null()
    {
        // Arrange
        var entity = _brandTestsFixture.GetBrand();
        var brandRepository = new Mock<IBrandRepository>();
        brandRepository.Setup(b => b.GetById(Guid.NewGuid())).ReturnsAsync(entity);
        var query = new GetBrandByIdQuery { Id = Guid.NewGuid().ToString() };
        var queryHandler = new GetBrandByIdQueryHandler(_mapper, brandRepository.Object);

        // Act
        var result = await queryHandler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }
}