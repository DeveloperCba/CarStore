using CarStore.Shop.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Shop.Infrastructure.Mappings;

public class BrandMapping : EntityMapping<Brand>
{
    private static string _nameTable = nameof(Brand);
    public BrandMapping() : base(_nameTable) { }
    public override void Configure(EntityTypeBuilder<Brand> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Status);

        builder.HasData( 
            new Brand("Volkswagen"),
            new Brand("Toyota"),
            new Brand("Ford"),
            new Brand("Honda"),
            new Brand("Hyundai")
         );
    }
}
