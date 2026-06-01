using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoClub.Api.Data.Entities;

namespace VideoClub.Api.Data.Configurations;

public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.ToTable("Generos");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Descripcion).HasColumnType("text").IsRequired();
    }
}
