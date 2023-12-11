using MediatR;
using PromAdmin.Core.Componentes.Departamentos.Dtos;

namespace PromAdmin.Core.Componentes.Departamentos.Queries.ListarDepartamentos;

public class ListarDepartamentosQuery:IRequest<IReadOnlyList<DepartamentoResponse>>
{
    
}