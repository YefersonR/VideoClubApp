using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoClub.Api.Data;
using VideoClub.Api.Features.Empleados.Queries;
using VideoClub.Shared;
using VideoClub.Shared.DTOs.Empleados;

namespace VideoClub.Api.Features.Empleados.Handlers;

public class GetEmpleadoByIdHandler : IRequestHandler<GetEmpleadoByIdQuery, Result<EmpleadoDto?>>
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public GetEmpleadoByIdHandler(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Result<EmpleadoDto?>> Handle(GetEmpleadoByIdQuery request, CancellationToken ct)
    {
        var entity = await _db.Empleados.FirstOrDefaultAsync(e => e.Id == request.Id, ct);

        if (entity is null)
            return Result<EmpleadoDto?>.Failure($"Empleado con Id {request.Id} no encontrado.");

        var dto = _mapper.Map<EmpleadoDto>(entity);
        return Result<EmpleadoDto?>.Success(dto);
    }
}
