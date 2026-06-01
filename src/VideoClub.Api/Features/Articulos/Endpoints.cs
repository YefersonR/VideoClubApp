using AutoMapper;
using MediatR;
using VideoClub.Api.Features.Articulos.Commands;
using VideoClub.Api.Features.Articulos.Queries;
using VideoClub.Shared.DTOs.Articulos;

namespace VideoClub.Api.Features.Articulos;

public static class Endpoints
{
    public static RouteGroupBuilder MapArticuloEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetAllArticulosQuery());
            return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.Problem(detail: result.Error, statusCode: 500);
        });

        group.MapGet("/{id:long}", async (long id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetArticuloByIdQuery(id));
            return result.IsSuccess
                ? result.Value is not null ? Results.Ok(result.Value) : Results.NotFound()
                : Results.NotFound(new { error = result.Error });
        });

        group.MapPost("/", async (CreateArticuloRequest request, IMapper mapper, IMediator mediator) =>
        {
            var command = mapper.Map<CreateArticuloCommand>(request);
            var result = await mediator.Send(command);
            return result.IsSuccess
                ? Results.Created($"/api/articulos/{result.Value!.Id}", result.Value)
                : Results.BadRequest(new { error = result.Error });
        });

        group.MapPut("/{id:long}", async (long id, UpdateArticuloRequest request, IMapper mapper, IMediator mediator) =>
        {
            var command = mapper.Map<UpdateArticuloCommand>(request) with { Id = id };
            var result = await mediator.Send(command);
            return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.NotFound(new { error = result.Error });
        });

        group.MapDelete("/{id:long}", async (long id, IMediator mediator) =>
        {
            var result = await mediator.Send(new DeleteArticuloCommand(id));
            return result.IsSuccess
                ? Results.NoContent()
                : Results.NotFound(new { error = result.Error });
        });

        return group;
    }
}
