namespace VideoClub.Api.Data.Entities;

public class ElencoArticulo
{
    public long ArticuloId { get; set; }
    public long ElencoId { get; set; }
    public long RolId { get; set; }

    public Articulo Articulo { get; set; } = null!;
    public Elenco Elenco { get; set; } = null!;
    public Rol Rol { get; set; } = null!;
}
