namespace VideoClub.Shared.DTOs.Articulos;

public record UpdateArticuloRequest
{
    public string Titulo { get; init; } = string.Empty;
    public long TipoArticuloId { get; init; }
    public long GeneroId { get; init; }
    public long IdiomaId { get; init; }
    public decimal RentaPorDia { get; init; }
    public int DiasRenta { get; init; } = 3;
    public decimal MontoEntregaTardia { get; init; }
    public int Stock { get; init; }
}
