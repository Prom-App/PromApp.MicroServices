using MediatR;
using PromAdmin.Core.Componentes.Agencias.Dtos;
using PromAdmin.Core.Componentes.Ciudades.Dtos;

namespace PromAdmin.Core.Componentes.Agencias.Queries.ListarAgencias;

public class ListarAgenciasQuery : IRequest<IReadOnlyList<AgenciaResponse>>
{
}