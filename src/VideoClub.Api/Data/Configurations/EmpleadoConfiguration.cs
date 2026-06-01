using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoClub.Api.Data.Entities;
using VideoClub.Shared.Enums;

namespace VideoClub.Api.Data.Configurations;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleados", t => t.HasCheckConstraint("CK_Empleados_TandaLabor", "tanda_labor IN ('Matutina', 'Vespertina')"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nombre).HasColumnType("text").IsRequired();
        builder.Property(e => e.Cedula).HasColumnType("text").IsRequired();
        builder.Property(e => e.TandaLabor).HasColumnName("tanda_labor").HasColumnType("text").IsRequired().HasConversion<string>();
        builder.Property(e => e.PorcientoComision).HasColumnType("numeric(5,2)").HasDefaultValue(0);
        builder.Property(e => e.FechaIngreso).HasColumnType("date").IsRequired();
        builder.Property(e => e.NombreUsuario).HasColumnName("nombre_usuario").HasColumnType("text").IsRequired();
        builder.Property(e => e.PasswordHash).HasColumnName("password_hash").HasColumnType("text").IsRequired();

        builder.HasIndex(e => e.Cedula).IsUnique();
        builder.HasIndex(e => e.NombreUsuario).IsUnique();
    }
}
