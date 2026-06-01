using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoClub.Api.Data;
using VideoClub.Api.Features.Articulos.Commands;
using VideoClub.Shared;

namespace VideoClub.Api.Features.Articulos.Handlers;

public class DeleteArticuloHandler : IRequestHandler<DeleteArticuloCommand, Result<bool>>
{
    private readonly AppDbContext _db;

    public DeleteArticuloHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result<bool>> Handle(DeleteArticuloCommand request, CancellationToken ct)
    {
        var entity = await _db.Articulos.FirstOrDefaultAsync(e => e.Id == request.Id, ct);

        if (entity is null)
            return Result<bool>.Failure($"Artículo con Id {request.Id} no encontrado.");

        entity.Estado = false;
        await _db.SaveChangesAsync(ct);

        return Result<bool>.Success(true);
    }
}
