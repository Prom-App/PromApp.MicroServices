using AutoMapper;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Componentes.Colegios.Dtos;
using PromAdmin.Core.Componentes.Generos.Dtos;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Mapeos;

public class PerfilMapeo : Profile
{
    public PerfilMapeo()
    {
        CreateMap<Ciudad, CiudadResponse>();
        CreateMap<Colegio, ColegioResponse>();
        CreateMap<Genero, GeneroResponse>();
    }
}