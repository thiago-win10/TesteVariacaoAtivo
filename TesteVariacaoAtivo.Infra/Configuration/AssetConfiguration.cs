using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteVariacaoAtivo.Domain.Entities;

namespace TesteVariacaoAtivo.Infra.Configuration
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AssetName)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.DataAsset)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(18, 2)
                .IsRequired();
        }

    }
}