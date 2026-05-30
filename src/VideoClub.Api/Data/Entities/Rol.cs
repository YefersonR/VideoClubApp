namespace VideoClub.Api.Data.Entities;

public class Rol
{
    public long Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public bool Estado { get; set; } = true;

    public ICollection<ElencoArticulo> ElencosArticulos { get; set; } = new List<ElencoArticulo>();
}
