using MediatR;
using PromAdmin.Core.Componentes.Agencias.Dtos;

namespace PromAdmin.Core.Componentes.Agencias.Queries.AgenciaPorId;

public class AgenciaPorIdQuery : IRequest<AgenciaResponse>
{
    public int IdAgencia { get; set; }

    public AgenciaPorIdQuery(int idAgencia)
    {
        IdAgencia = idAgencia < 1 ? throw new ArgumentNullException(nameof(idAgencia)) : idAgencia;
    }
}