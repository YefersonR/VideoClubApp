namespace VideoClub.Api.Data.Entities;

public class TipoArticulo
{
    public long Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public bool Estado { get; set; } = true;

    public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
}
