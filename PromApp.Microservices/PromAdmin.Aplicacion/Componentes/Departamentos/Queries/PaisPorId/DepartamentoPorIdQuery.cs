using MediatR;
using PromAdmin.Core.Componentes.Departamentos.Dtos;

namespace PromAdmin.Core.Componentes.Departamentos.Queries.PaisPorId;

public class DepartamentoPorIdQuery: IRequest<DepartamentoResponse>
{
    public int IdDepartamento { get; set; }

    public DepartamentoPorIdQuery(int idDepartamento)
    {
        IdDepartamento = idDepartamento < 1 ? throw new ArgumentNullException(nameof(idDepartamento)) : idDepartamento;
    }
}