using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoClub.Api.Data.Entities;

namespace VideoClub.Api.Data.Configurations;

public class ElencoConfiguration : IEntityTypeConfiguration<Elenco>
{
    public void Configure(EntityTypeBuilder<Elenco> builder)
    {
        builder.ToTable("Elenco");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Nombre).HasColumnType("text").IsRequired();
        builder.Property(e => e.Estado).HasDefaultValue(true);
    }
}
