using AutoMapper;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Application.Features.Brand.Queries;
using CarStore.Shop.Application.Features.Brand.QueriesHandlers;
using CarStore.Shop.Domain.Interfaces;
using CarStore.Shop.Domain.Models;
using CarStore.Shop.Unit.Test.Brands.Configurations;
using Core.Test.Configurations;
using FluentAssertions;
using Moq;

namespace CarStore.Shop.Unit.Test.Brands
{
    [Collection(nameof(BrandTestsCollection))]
    public class GetBrandAllQueryHandlerTests
    {
        private readonly BrandTestsFixture _brandTestsFixture;
        private readonly IMapper _mapper;

        public GetBrandAllQueryHandlerTests(BrandTestsFixture brandTestsFixture)
        {
            _brandTestsFixture = brandTestsFixture;
            _mapper = AutoMapperConfiguration.GetMapperConfiguration();
        }

        [Fact(DisplayName = "GetBrandAll Brand Should be valid")]
        [Trait("Brand Application", "GetBrandAll - GetBrandAll Brand Command Handler")]
        public async Task GetBrandAll_ShouldBe_Successufly()
        {
            // Arrange
            var entities = _brandTestsFixture.GetBrands();
            var brandRepository = new Mock<IBrandRepository>();
            brandRepository.Setup(b => b.GetAll(null)).ReturnsAsync(entities);
            var query = new GetBrandAllQuery();
            var queryHandler = new GetBrandAllQueryHandler(_mapper, brandRepository.Object);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().HaveCountGreaterOrEqualTo(10);
        }


        [Fact(DisplayName = "GetBrandAll Brand Should be invalid")]
        [Trait("Brand Application", "GetBrandAll - GetBrandAll Brand Command Handler")]
        public async Task GetBrandAll_ShouldBe_Null()
        {
            // Arrange
            var entities = new List<Brand>();
            var brandRepository = new Mock<IBrandRepository>();
            brandRepository.Setup(b => b.GetAll(null)).ReturnsAsync(entities);
            var query = new GetBrandAllQuery();
            var queryHandler = new GetBrandAllQueryHandler(_mapper, brandRepository.Object);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().HaveCountGreaterOrEqualTo(0);
        }
    }
}