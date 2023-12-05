using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Specifications.Agencias;

public class AgenciaSpecification : BaseSpecification<Agencia>
{
    public AgenciaSpecification(AgenciaSpecificationParams agenciaParams) : base(
        x =>
            string.IsNullOrEmpty(agenciaParams.Search) || x.Nombre!.Contains(agenciaParams.Search)
    )
    {
        ApplyPaging(agenciaParams.PageSize * (agenciaParams.PageIndex - 1), agenciaParams.PageSize);

        if (!string.IsNullOrEmpty(agenciaParams.Sort))
        {
            switch (agenciaParams.Sort)
            {
                case "nombreAsc":
                    AddOrderBy(x => x.Nombre!);
                    break;
                case "nombreDesc":
                    AddOrderByDescending(x => x.Nombre!);
                    break;
                default:
                    AddOrderBy(x => x.Nombre!);
                    break;
            }
        }
        else
        {
            AddOrderByDescending(x => x.Nombre!);
        }
    }
}