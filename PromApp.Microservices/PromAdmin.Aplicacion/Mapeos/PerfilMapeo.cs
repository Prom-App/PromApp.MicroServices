using AutoMapper;
using PromAdmin.Core.Componentes.Ciudades.Commands.ActualizarCiudad;
using PromAdmin.Core.Componentes.Ciudades.Commands.CrearCiudad;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Componentes.Colegios.Dtos;
using PromAdmin.Core.Componentes.Generos.Dtos;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Mapeos;

public class PerfilMapeo : Profile
{
    public PerfilMapeo()
    {
        CreateMap<Colegio, ColegioResponse>();
        CreateMap<Genero, GeneroResponse>();

        CreateMap<Ciudad, CiudadResponse>();
        CreateMap<CrearCiudadCommand, Ciudad>();
        CreateMap<ActualizarCiudadCommand, Ciudad>();
    }
}