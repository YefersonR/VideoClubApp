using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoClub.Api.Data.Entities;

namespace VideoClub.Api.Data.Configurations;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleados", t => t.HasCheckConstraint("CK_Empleados_TandaLabor", "tanda_labor IN ('Matutina', 'Vespertina')"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nombre).HasColumnType("text").IsRequired();
        builder.Property(e => e.Cedula).HasColumnType("text").IsRequired();
        builder.Property(e => e.TandaLabor).HasColumnName("tanda_labor").HasColumnType("text").IsRequired();
        builder.Property(e => e.PorcientoComision).HasColumnType("numeric(5,2)").HasDefaultValue(0);
        builder.Property(e => e.FechaIngreso).HasColumnType("date").IsRequired();
        builder.Property(e => e.Estado).HasDefaultValue(true);

        builder.HasIndex(e => e.Cedula).IsUnique();
    }
}
