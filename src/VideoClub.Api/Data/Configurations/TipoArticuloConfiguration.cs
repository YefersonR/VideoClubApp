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
        builder.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion").HasColumnType("timestamptz").HasDefaultValueSql("now()");
        builder.Property(e => e.FechaModificacion).HasColumnName("fecha_modificacion").HasColumnType("timestamptz");
        builder.Property(e => e.UsuarioCreacion).HasColumnName("usuario_creacion").HasColumnType("text").IsRequired();
        builder.Property(e => e.UsuarioModificacion).HasColumnName("usuario_modificacion").HasColumnType("text");
    }
}
