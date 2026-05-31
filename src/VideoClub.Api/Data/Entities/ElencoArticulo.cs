namespace VideoClub.Api.Data.Entities;

public class ElencoArticulo
{
    public long ArticuloId { get; set; }
    public long ElencoId { get; set; }
    public long RolElencoId { get; set; }

    public Articulo Articulo { get; set; } = null!;
    public Elenco Elenco { get; set; } = null!;
    public RolElenco RolElenco { get; set; } = null!;
}
