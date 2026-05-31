using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoClub.Api.Data.Entities;

namespace VideoClub.Api.Data.Configurations;

public class ElencoArticuloConfiguration : IEntityTypeConfiguration<ElencoArticulo>
{
    public void Configure(EntityTypeBuilder<ElencoArticulo> builder)
    {
        builder.ToTable("ElencoArticulo");
        builder.HasKey(e => new { e.ArticuloId, e.ElencoId, e.RolElencoId });

        builder.HasOne(e => e.Articulo)
            .WithMany(a => a.Elencos)
            .HasForeignKey(e => e.ArticuloId);

        builder.HasOne(e => e.Elenco)
            .WithMany(el => el.Articulos)
            .HasForeignKey(e => e.ElencoId);

        builder.HasOne(e => e.RolElenco)
            .WithMany(r => r.ElencosArticulos)
            .HasForeignKey(e => e.RolElencoId);

        builder.HasIndex(e => e.ArticuloId);
        builder.HasIndex(e => e.ElencoId);
        builder.HasIndex(e => e.RolElencoId);
    }
}
