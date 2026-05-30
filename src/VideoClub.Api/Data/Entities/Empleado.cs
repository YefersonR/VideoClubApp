namespace VideoClub.Api.Data.Entities;

public class Empleado
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Cedula { get; set; } = string.Empty;
    public string TandaLabor { get; set; } = string.Empty;
    public decimal PorcientoComision { get; set; }
    public DateOnly FechaIngreso { get; set; }
    public bool Estado { get; set; } = true;

    public ICollection<RentaDevolucion> Rentas { get; set; } = new List<RentaDevolucion>();
}
