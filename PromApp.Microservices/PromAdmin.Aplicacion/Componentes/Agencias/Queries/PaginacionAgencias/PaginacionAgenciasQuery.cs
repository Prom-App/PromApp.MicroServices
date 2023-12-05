using MediatR;
using PromAdmin.Core.Componentes.Agencias.Dtos;
using PromAdmin.Core.Componentes.Compartidos.Dtos;
using PromAdmin.Core.Componentes.Compartidos.Queries;

namespace PromAdmin.Core.Componentes.Agencias.Queries.PaginacionAgencias;

public class PaginacionAgenciasQuery: PaginacionBaseQuery, IRequest<PaginacionDto<AgenciaResponse>>
{
}