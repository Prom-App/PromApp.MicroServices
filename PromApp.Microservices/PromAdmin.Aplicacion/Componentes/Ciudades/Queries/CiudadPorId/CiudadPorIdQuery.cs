using MediatR;
using PromAdmin.Core.Componentes.Ciudades.Dtos;

namespace PromAdmin.Core.Componentes.Ciudades.Queries.CiudadPorId;

public class CiudadPorIdQuery : IRequest<CiudadResponse>
{
    public int IdCiudad { get; set; }

    public CiudadPorIdQuery(int idCiudad)
    {
        IdCiudad = idCiudad < 1 ? throw new ArgumentNullException(nameof(idCiudad)) : idCiudad;
    }
}