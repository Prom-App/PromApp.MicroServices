using MediatR;
using PromAdmin.Core.Componentes.Paises.Dtos;

namespace PromAdmin.Core.Componentes.Paises.Queries.ListarPaises;

public class ListarPaisesQuery:IRequest<IReadOnlyList<PaisResponse>>
{
}