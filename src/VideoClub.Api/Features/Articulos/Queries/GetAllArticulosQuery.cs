using MediatR;
using VideoClub.Shared;
using VideoClub.Shared.DTOs.Articulos;

namespace VideoClub.Api.Features.Articulos.Queries;

public record GetAllArticulosQuery : IRequest<Result<List<ArticuloDto>>>;
