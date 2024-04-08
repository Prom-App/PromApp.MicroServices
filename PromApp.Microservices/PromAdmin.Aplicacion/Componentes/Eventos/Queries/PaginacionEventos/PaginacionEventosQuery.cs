using MediatR;
using PromAdmin.Core.Componentes.Compartidos.Dtos;
using PromAdmin.Core.Componentes.Compartidos.Queries;
using PromAdmin.Core.Componentes.Eventos.Dtos;

namespace PromAdmin.Core.Componentes.Eventos.Queries.PaginacionEventos;

public class PaginacionEventosQuery: PaginacionBaseQuery,IRequest<PaginacionDto<EventoResponse>>
{
}