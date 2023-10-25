using CarStore.Shop.Domain.Models;
using CarStore.Shop.Domain.Validations.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStore.Shop.Infrastructure.Mappings;

public class OwnerMapping : EntityMapping<Owner>
{
    private static string _nameTable = nameof(Owner);
    public OwnerMapping() : base(_nameTable) { }
    public override void Configure(EntityTypeBuilder<Owner> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Document).HasMaxLength(14);
        builder.Property(x => x.OwnerType);
        builder.Property(x => x.Status);


        builder.OwnsOne(c => c.Email, tf =>
        {
            tf.Property(c => c.Address)
                .HasColumnName(nameof(Email))
                .IsRequired()
                .HasMaxLength(Email.AddressMaxLength);
        });

        // 1 : 1 => Proprietario : Endereco
        builder.HasOne(c => c.Address);
    }
}
