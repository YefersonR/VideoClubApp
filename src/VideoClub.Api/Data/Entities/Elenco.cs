namespace VideoClub.Api.Data.Entities;

public class Elenco
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public bool Estado { get; set; } = true;

    public ICollection<ElencoArticulo> Articulos { get; set; } = new List<ElencoArticulo>();
}
