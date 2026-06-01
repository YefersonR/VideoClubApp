using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoClub.Api.Data.Entities;

namespace VideoClub.Api.Data.Configurations;

public class ArticuloConfiguration : IEntityTypeConfiguration<Articulo>
{
    public void Configure(EntityTypeBuilder<Articulo> builder)
    {
        builder.ToTable("Articulos");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Titulo).HasColumnType("text").IsRequired();
        builder.Property(e => e.RentaPorDia).HasColumnName("renta_por_dia").HasColumnType("numeric(10,2)").IsRequired();
        builder.Property(e => e.DiasRenta).HasDefaultValue(3);
        builder.Property(e => e.MontoEntregaTardia).HasColumnType("numeric(10,2)").HasDefaultValue(0);
        builder.Property(e => e.Stock).HasDefaultValue(0);

        builder.HasOne(e => e.TipoArticulo)
            .WithMany(t => t.Articulos)
            .HasForeignKey(e => e.TipoArticuloId);

        builder.HasOne(e => e.Genero)
            .WithMany(g => g.Articulos)
            .HasForeignKey(e => e.GeneroId);

        builder.HasOne(e => e.Idioma)
            .WithMany(i => i.Articulos)
            .HasForeignKey(e => e.IdiomaId);

        builder.HasIndex(e => e.TipoArticuloId);
        builder.HasIndex(e => e.GeneroId);
        builder.HasIndex(e => e.IdiomaId);

    }
}
