namespace VideoClub.Api.Data.Entities;

public abstract class AuditableEntity
{
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public string UsuarioCreacion { get; set; } = string.Empty;
    public string? UsuarioModificacion { get; set; }
    public bool Estado { get; set; } = true;
}
