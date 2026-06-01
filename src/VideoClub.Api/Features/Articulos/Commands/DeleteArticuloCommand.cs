using MediatR;
using VideoClub.Shared;

namespace VideoClub.Api.Features.Articulos.Commands;

public record DeleteArticuloCommand(long Id) : IRequest<Result<bool>>;
