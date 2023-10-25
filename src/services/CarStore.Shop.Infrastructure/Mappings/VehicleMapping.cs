using CarStore.Shop.Domain.Models;
using CarStore.Shop.Domain.Validations.Documents;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Shop.Infrastructure.Mappings;

public class VehicleMapping : EntityMapping<Vehicle>
{
    private static string _nameTable = nameof(Vehicle);
    public VehicleMapping() : base(_nameTable) { }
    public override void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Renavam).HasMaxLength(RenavamValidacao.LengthRenavam);
        builder.Property(x => x.BrandId).HasMaxLength(36);
        builder.Property(x => x.OwnerId).HasMaxLength(36);
        builder.Property(x => x.Kilometer);
        builder.Property(x => x.Price).HasPrecision(18,2);

        builder.Property(x => x.Status);

        builder.HasOne(c => c.Model);
        builder.HasOne(c => c.Owner);
        builder.HasOne(c => c.Brand);

    }
}