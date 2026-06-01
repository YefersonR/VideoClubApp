using MediatR;
using VideoClub.Shared;

namespace VideoClub.Api.Features.Empleados.Commands;

public record DeleteEmpleadoCommand(long Id) : IRequest<Result<bool>>;
