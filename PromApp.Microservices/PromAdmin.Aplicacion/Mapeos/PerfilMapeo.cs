using AutoMapper;
using PromAdmin.Core.Componentes.Avatares.Dtos;
using PromAdmin.Core.Componentes.Ciudades.Commands.ActualizarCiudad;
using PromAdmin.Core.Componentes.Ciudades.Commands.CrearCiudad;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Componentes.Colegios.Dtos;
using PromAdmin.Core.Componentes.Departamentos.Dtos;
using PromAdmin.Core.Componentes.Generos.Dtos;
using PromAdmin.Core.Componentes.Nacionalidades.Commands.CrearNacionalidad;
using PromAdmin.Core.Componentes.Nacionalidades.Dtos;
using PromAdmin.Core.Componentes.Paises.Dtos;
using PromAdmin.Core.Componentes.Tests.Dtos;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Mapeos;

public class PerfilMapeo : Profile
{
    public PerfilMapeo()
    {
        CreateMap<Colegio, ColegioResponse>();
        CreateMap<Genero, GeneroResponse>();

        CreateMap<CrearNacionalidadCommand, Nacionalidad>()
            .ForMember(x => x.Descripcion, y => y.MapFrom(z => z.Nacionalidad))
            .ForMember(x => x.IdPais, y => y.MapFrom(z => z.IdPais));
        CreateMap<Nacionalidad, NacionalidadResponse>()
            .ForMember(x => x.Nacionalidad, y => y.MapFrom(z => z.Descripcion))
            .ForMember(x => x.Pais, y => y.MapFrom(z => z.Pais!.Nombre));

        CreateMap<Avatar, AvatarResponse>();
        CreateMap<Departamento, DepartamentoResponse>();
        CreateMap<Pais, PaisResponse>();
        CreateMap<Test, TestResponse>();
        CreateMap<Seccion, SeccionResponse>();
        CreateMap<Pregunta, PreguntaResponse>();
        CreateMap<TipoPregunta, TipoPreguntaResponse>();
        CreateMap<Respuesta, RespuestaResponse>();
        
        CreateMap<CrearCiudadCommand, Ciudad>();
        CreateMap<ActualizarCiudadCommand, Ciudad>();
        CreateMap<Ciudad, CiudadResponse>();

        CreateMap<MBTIResultado, ResultadoMBTIResponse>();
    }
}