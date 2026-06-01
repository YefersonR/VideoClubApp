using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoClub.Api.Data.Entities;

namespace VideoClub.Api.Data.Configurations;

public class IdiomaConfiguration : IEntityTypeConfiguration<Idioma>
{
    public void Configure(EntityTypeBuilder<Idioma> builder)
    {
        builder.ToTable("Idiomas");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Descripcion).HasColumnType("text").IsRequired();
    }
}
