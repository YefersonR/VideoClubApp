namespace VideoClub.Api.Data.Entities;

public class TipoArticuloGenero
{
    public long TipoArticuloId { get; set; }
    public long GeneroId { get; set; }

    public TipoArticulo TipoArticulo { get; set; } = null!;
    public Genero Genero { get; set; } = null!;
}
