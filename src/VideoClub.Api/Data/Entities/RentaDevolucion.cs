namespace VideoClub.Api.Data.Entities;

public class RentaDevolucion : AuditableEntity
{
    public long Id { get; set; }
    public string NoRenta { get; set; } = string.Empty;
    public long EmpleadoId { get; set; }
    public long ArticuloId { get; set; }
    public long ClienteId { get; set; }
    public DateTime FechaRenta { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public decimal MontoXdia { get; set; }
    public int CantidadDias { get; set; }
    public int DiasRetraso { get; private set; }
    public string? Comentario { get; set; }

    public Empleado Empleado { get; set; } = null!;
    public Articulo Articulo { get; set; } = null!;
    public Cliente Cliente { get; set; } = null!;
}
