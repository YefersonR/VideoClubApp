using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoClub.Api.Data;
using VideoClub.Api.Features.Articulos.Queries;
using VideoClub.Shared;
using VideoClub.Shared.DTOs.Articulos;

namespace VideoClub.Api.Features.Articulos.Handlers;

public class GetArticuloByIdHandler : IRequestHandler<GetArticuloByIdQuery, Result<ArticuloDto?>>
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public GetArticuloByIdHandler(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Result<ArticuloDto?>> Handle(GetArticuloByIdQuery request, CancellationToken ct)
    {
        var entity = await _db.Articulos
            .Include(e => e.TipoArticulo)
            .Include(e => e.Genero)
            .Include(e => e.Idioma)
            .FirstOrDefaultAsync(e => e.Id == request.Id, ct);

        if (entity is null)
            return Result<ArticuloDto?>.Failure($"Artículo con Id {request.Id} no encontrado.");

        var dto = _mapper.Map<ArticuloDto>(entity);
        return Result<ArticuloDto?>.Success(dto);
    }
}
