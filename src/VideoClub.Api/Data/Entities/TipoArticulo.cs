namespace VideoClub.Api.Data.Entities;

public class TipoArticulo : AuditableEntity
{
    public long Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;

    public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
    public ICollection<TipoArticuloGenero> TiposArticulosGeneros { get; set; } = new List<TipoArticuloGenero>();
}
