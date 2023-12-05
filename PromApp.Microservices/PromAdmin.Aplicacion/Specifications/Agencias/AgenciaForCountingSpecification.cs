using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Specifications.Agencias;

public class AgenciaForCountingSpecification : BaseSpecification<Agencia>
{
    public AgenciaForCountingSpecification(AgenciaSpecificationParams agenciaParams)
        : base(
            x =>
                string.IsNullOrEmpty(agenciaParams.Search) || x.Nombre!.Contains(agenciaParams.Search)
        )
    {
    }
}