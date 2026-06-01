using AutoMapper;
using MediatR;
using VideoClub.Api.Features.Empleados.Commands;
using VideoClub.Api.Features.Empleados.Queries;
using VideoClub.Shared.DTOs.Empleados;

namespace VideoClub.Api.Features.Empleados;

public static class Endpoints
{
    public static RouteGroupBuilder MapEmpleadoEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllEmpleadosQuery());
            return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.Problem(detail: result.Error, statusCode: 500);
        });

        group.MapGet("/{id:long}", async (long id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetEmpleadoByIdQuery(id));
            return result.IsSuccess
                ? result.Value is not null ? Results.Ok(result.Value) : Results.NotFound()
                : Results.NotFound(new { error = result.Error });
        });

        group.MapPost("/", async (CreateEmpleadoRequest request, IMapper mapper, IMediator mediator) =>
        {
            var command = mapper.Map<CreateEmpleadoCommand>(request);
            var result = await mediator.Send(command);
            return result.IsSuccess
                ? Results.Created($"/api/empleados/{result.Value!.Id}", result.Value)
                : Results.BadRequest(new { error = result.Error });
        });

        group.MapPut("/{id:long}", async (long id, UpdateEmpleadoRequest request, IMapper mapper, IMediator mediator) =>
        {
            var command = mapper.Map<UpdateEmpleadoCommand>(request) with { Id = id };
            var result = await mediator.Send(command);
            return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.NotFound(new { error = result.Error });
        });

        group.MapDelete("/{id:long}", async (long id, IMediator mediator) =>
        {
            var result = await mediator.Send(new DeleteEmpleadoCommand(id));
            return result.IsSuccess
                ? Results.NoContent()
                : Results.NotFound(new { error = result.Error });
        });

        return group;
    }
}
