using AutoMapper;
using VideoClub.Api.Data.Entities;
using VideoClub.Api.Features.Empleados.Commands;
using VideoClub.Shared.DTOs.Empleados;

namespace VideoClub.Api.Features.Empleados.Mapping;

public class EmpleadoProfile : Profile
{
    public EmpleadoProfile()
    {
        CreateMap<Empleado, EmpleadoDto>();

        CreateMap<CreateEmpleadoCommand, Empleado>();
        CreateMap<UpdateEmpleadoCommand, Empleado>();

        CreateMap<CreateEmpleadoRequest, CreateEmpleadoCommand>();
        CreateMap<UpdateEmpleadoRequest, UpdateEmpleadoCommand>()
            .ForMember(d => d.Id, o => o.Ignore());
    }
}
