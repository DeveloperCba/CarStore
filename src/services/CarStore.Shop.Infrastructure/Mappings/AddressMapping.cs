using CarStore.Shop.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Shop.Infrastructure.Mappings;

public class AddressMapping : EntityMapping<Address>
{
    private static string _nameTable = nameof(Address);
    public AddressMapping() : base(_nameTable) { }
    public override void Configure(EntityTypeBuilder<Address> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Street).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Number).HasMaxLength(20).IsRequired();
        builder.Property(x => x.ZipCode).HasMaxLength(20).IsRequired();
        builder.Property(x => x.Complement).HasMaxLength(250);
        builder.Property(x => x.Neighborhood).HasMaxLength(100).IsRequired();
        builder.Property(x => x.City).HasMaxLength(100).IsRequired();
        builder.Property(x => x.State).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Owner).HasMaxLength(36);

        builder.HasData(
            new Address("Rua 10", "01", "Quadra 15", "Centro", "78098000", "Cuiabá", "MT", Guid.Empty),
            new Address("Rua Brazil", "10", "Quadra 36", "Porto", "78098000", "Cuiabá", "MT", Guid.Empty),
            new Address("Rua Orquideas", "01", "Quadra 98", "Jardim Universitário", "78098000", "Cuiabá", "MT", Guid.Empty),
            new Address("Rua 42", "395", "Quadra 70", "Jardim Imperial", "78098000", "Cuiabá", "MT", Guid.Empty)
            );
    }
}
