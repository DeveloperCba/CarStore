using CarStore.Shop.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Shop.Infrastructure.Mappings;

public class ModelMapping : EntityMapping<Model>
{
    private static string _nameTable = nameof(Model);
    public ModelMapping() : base(_nameTable) { }
    public override void Configure(EntityTypeBuilder<Model> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Description).HasMaxLength(50);
        builder.Property(x => x.YearModel);
        builder.Property(x => x.YearManufacturing);
        builder.Property(x => x.VehicleId).HasMaxLength(36);

    }
}

