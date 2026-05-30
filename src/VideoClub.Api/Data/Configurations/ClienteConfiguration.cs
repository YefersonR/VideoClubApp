using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoClub.Api.Data.Entities;

namespace VideoClub.Api.Data.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes", t => t.HasCheckConstraint("CK_Clientes_NoTarjetaCr", "no_tarjeta_cr ~ '^[0-9]{4}$'"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nombre).HasColumnType("text").IsRequired();
        builder.Property(e => e.Cedula).HasColumnType("text").IsRequired();
        builder.Property(e => e.NoTarjetaCr).HasColumnName("no_tarjeta_cr").HasColumnType("char(4)").IsRequired().HasMaxLength(4);
        builder.Property(e => e.LimiteCredito).HasColumnType("numeric(10,2)").HasDefaultValue(0);
        builder.Property(e => e.TipoPersona).HasColumnType("text").IsRequired();
        builder.Property(e => e.Estado).HasDefaultValue(true);

        builder.HasIndex(e => e.Cedula).IsUnique();
    }
}
