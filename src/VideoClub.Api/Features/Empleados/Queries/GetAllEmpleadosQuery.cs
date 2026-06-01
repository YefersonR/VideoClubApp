using MediatR;
using VideoClub.Shared;
using VideoClub.Shared.DTOs.Empleados;

namespace VideoClub.Api.Features.Empleados.Queries;

public record GetAllEmpleadosQuery : IRequest<Result<List<EmpleadoDto>>>;
