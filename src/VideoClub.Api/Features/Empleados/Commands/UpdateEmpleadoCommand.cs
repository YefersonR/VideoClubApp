using MediatR;
using VideoClub.Shared;
using VideoClub.Shared.DTOs.Empleados;
using VideoClub.Shared.Enums;

namespace VideoClub.Api.Features.Empleados.Commands;

public record UpdateEmpleadoCommand(
    long Id,
    string Nombre,
    string Cedula,
    TandaLabor TandaLabor,
    decimal PorcientoComision,
    DateOnly FechaIngreso,
    string NombreUsuario,
    string Password
) : IRequest<Result<EmpleadoDto>>;
