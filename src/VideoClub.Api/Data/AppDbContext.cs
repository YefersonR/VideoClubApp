using Microsoft.EntityFrameworkCore;
using VideoClub.Api.Data.Entities;

namespace VideoClub.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TipoArticulo> TiposArticulos => Set<TipoArticulo>();
    public DbSet<Genero> Generos => Set<Genero>();
    public DbSet<Idioma> Idiomas => Set<Idioma>();
    public DbSet<Articulo> Articulos => Set<Articulo>();
    public DbSet<Elenco> Elenco => Set<Elenco>();
    public DbSet<ElencoArticulo> ElencosArticulos => Set<ElencoArticulo>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Empleado> Empleados => Set<Empleado>();
    public DbSet<RolElenco> RolesElenco => Set<RolElenco>();
    public DbSet<RentaDevolucion> RentasDevoluciones => Set<RentaDevolucion>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
