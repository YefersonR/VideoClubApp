using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoClub.Api.Data;
using VideoClub.Api.Features.Empleados.Queries;
using VideoClub.Shared;
using VideoClub.Shared.DTOs.Empleados;

namespace VideoClub.Api.Features.Empleados.Handlers;

public class GetAllEmpleadosHandler : IRequestHandler<GetAllEmpleadosQuery, Result<List<EmpleadoDto>>>
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public GetAllEmpleadosHandler(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Result<List<EmpleadoDto>>> Handle(GetAllEmpleadosQuery request, CancellationToken ct)
    {
        var entities = await _db.Empleados.ToListAsync(ct);
        var dtos = _mapper.Map<List<EmpleadoDto>>(entities);
        return Result<List<EmpleadoDto>>.Success(dtos);
    }
}
