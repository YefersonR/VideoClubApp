namespace VideoClub.Api.Data.Entities;

public class Cliente
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Cedula { get; set; } = string.Empty;
    public string NoTarjetaCr { get; set; } = string.Empty;
    public decimal LimiteCredito { get; set; }
    public string TipoPersona { get; set; } = string.Empty;
    public bool Estado { get; set; } = true;

    public ICollection<RentaDevolucion> Rentas { get; set; } = new List<RentaDevolucion>();
}
