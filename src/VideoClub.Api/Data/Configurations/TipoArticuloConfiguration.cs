using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoClub.Api.Data.Entities;

namespace VideoClub.Api.Data.Configurations;

public class TipoArticuloConfiguration : IEntityTypeConfiguration<TipoArticulo>
{
    public void Configure(EntityTypeBuilder<TipoArticulo> builder)
    {
        builder.ToTable("TiposArticulos");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Descripcion).HasColumnType("text").IsRequired();
        builder.Property(e => e.Estado).HasDefaultValue(true);
    }
}
