using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoClub.Api.Data.Entities;

namespace VideoClub.Api.Data.Configurations;

public class TipoArticuloGeneroConfiguration : IEntityTypeConfiguration<TipoArticuloGenero>
{
    public void Configure(EntityTypeBuilder<TipoArticuloGenero> builder)
    {
        builder.ToTable("TiposArticulosGeneros");
        builder.HasKey(e => new { e.TipoArticuloId, e.GeneroId });

        builder.HasOne(e => e.TipoArticulo)
            .WithMany(t => t.TiposArticulosGeneros)
            .HasForeignKey(e => e.TipoArticuloId);

        builder.HasOne(e => e.Genero)
            .WithMany(g => g.TiposArticulosGeneros)
            .HasForeignKey(e => e.GeneroId);

        builder.HasIndex(e => e.TipoArticuloId);
        builder.HasIndex(e => e.GeneroId);
    }
}
