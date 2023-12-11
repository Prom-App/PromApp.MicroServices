using MediatR;
using PromAdmin.Core.Componentes.Generos.Dtos;

namespace PromAdmin.Core.Componentes.Generos.Queries.ListarGeneros;

public class ListarGenerosQuery:IRequest<IReadOnlyList<GeneroResponse>>
{
    
}