using MediatR;
using PromAdmin.Core.Componentes.Paises.Dtos;

namespace PromAdmin.Core.Componentes.Paises.Queries.PaisPorId;

public class PaisPorIdQuery: IRequest<PaisResponse>
{
    public int IdPais { get; set; }

    public PaisPorIdQuery(int idPais)
    {
        IdPais = idPais < 1 ? throw new ArgumentNullException(nameof(idPais)) : idPais;
    }
}