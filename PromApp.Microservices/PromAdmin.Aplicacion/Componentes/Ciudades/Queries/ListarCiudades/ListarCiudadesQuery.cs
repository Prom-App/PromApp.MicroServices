using MediatR;
using PromAdmin.Core.Componentes.Ciudades.Dtos;

namespace PromAdmin.Core.Componentes.Ciudades.Queries.ListarCiudades;

public class ListarCiudadesQuery : IRequest<IReadOnlyList<CiudadResponse>>
{
}