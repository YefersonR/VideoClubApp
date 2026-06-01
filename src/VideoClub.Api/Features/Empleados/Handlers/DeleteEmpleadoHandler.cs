using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoClub.Api.Data;
using VideoClub.Api.Features.Empleados.Commands;
using VideoClub.Shared;

namespace VideoClub.Api.Features.Empleados.Handlers;

public class DeleteEmpleadoHandler : IRequestHandler<DeleteEmpleadoCommand, Result<bool>>
{
    private readonly AppDbContext _db;

    public DeleteEmpleadoHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result<bool>> Handle(DeleteEmpleadoCommand request, CancellationToken ct)
    {
        var entity = await _db.Empleados.FirstOrDefaultAsync(e => e.Id == request.Id, ct);

        if (entity is null)
            return Result<bool>.Failure($"Empleado con Id {request.Id} no encontrado.");

        entity.Estado = false;
        await _db.SaveChangesAsync(ct);

        return Result<bool>.Success(true);
    }
}
