using MediatR;
using VideoClub.Shared;
using VideoClub.Shared.DTOs.Empleados;

namespace VideoClub.Api.Features.Empleados.Queries;

public record GetEmpleadoByIdQuery(long Id) : IRequest<Result<EmpleadoDto?>>;
