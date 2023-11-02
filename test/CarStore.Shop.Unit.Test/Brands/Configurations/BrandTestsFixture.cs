using Bogus;
using CarStore.Shop.Domain.Models;

namespace CarStore.Shop.Unit.Test.Brands.Configurations;


[CollectionDefinition(nameof(BrandTestsCollection))]
public class BrandTestsCollection : ICollectionFixture<BrandTestsFixture>{}

public class BrandTestsFixture : IDisposable
{

    public Brand GetBrand()
    {
        return Generate(1).FirstOrDefault()!;
    }

    public IEnumerable<Brand> GetBrands()
    {
        return Generate(10);
    }

    public IEnumerable<Brand> Generate(int count)
    {
        var brands = new Faker<Brand>("pt_BR")
            .CustomInstantiator(f => new Brand(
                name: f.Vehicle.Manufacturer()
            ))
            .RuleFor(x=>x.Status,f=> TypeStatus.Active)
            ;

        return brands.Generate(count);
    }


    public void Dispose()
    {}
}