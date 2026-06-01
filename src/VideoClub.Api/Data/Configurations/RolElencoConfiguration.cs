using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoClub.Api.Data.Entities;

namespace VideoClub.Api.Data.Configurations;

public class RolElencoConfiguration : IEntityTypeConfiguration<RolElenco>
{
    public void Configure(EntityTypeBuilder<RolElenco> builder)
    {
        builder.ToTable("RolesElenco");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Descripcion).HasColumnType("text").IsRequired();
    }
}
