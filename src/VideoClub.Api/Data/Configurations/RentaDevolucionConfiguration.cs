using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoClub.Api.Data.Entities;

namespace VideoClub.Api.Data.Configurations;

public class RentaDevolucionConfiguration : IEntityTypeConfiguration<RentaDevolucion>
{
    public void Configure(EntityTypeBuilder<RentaDevolucion> builder)
    {
        builder.ToTable("RentaDevolucion");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.NoRenta).HasColumnType("text").IsRequired();
        builder.Property(e => e.FechaRenta).HasColumnName("fecha_renta").HasColumnType("timestamptz").HasDefaultValueSql("now()");
        builder.Property(e => e.FechaDevolucion).HasColumnName("fecha_devolucion").HasColumnType("timestamptz");
        builder.Property(e => e.CantidadDias).HasColumnName("cantidad_dias").IsRequired();
        builder.Property(e => e.MontoXdia).HasColumnType("numeric(10,2)").IsRequired();
        builder.Property(e => e.DiasRetraso).HasDefaultValue(0);
        builder.Property(e => e.Comentario).HasColumnType("text");

        builder.HasOne(e => e.Empleado)
            .WithMany(em => em.Rentas)
            .HasForeignKey(e => e.EmpleadoId);

        builder.HasOne(e => e.Articulo)
            .WithMany(a => a.Rentas)
            .HasForeignKey(e => e.ArticuloId);

        builder.HasOne(e => e.Cliente)
            .WithMany(c => c.Rentas)
            .HasForeignKey(e => e.ClienteId);

        builder.HasIndex(e => e.NoRenta).IsUnique();
        builder.HasIndex(e => e.EmpleadoId);
        builder.HasIndex(e => e.ArticuloId);
        builder.HasIndex(e => e.ClienteId);
        builder.HasIndex(e => e.FechaRenta);

    }
}
