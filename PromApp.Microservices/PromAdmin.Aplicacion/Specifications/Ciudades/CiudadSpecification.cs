using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Specifications.Ciudades;

public class CiudadSpecification : BaseSpecification<Ciudad>
{
    public CiudadSpecification(CiudadSpecificationParams ciudadParams) : base(
        x =>
            string.IsNullOrEmpty(ciudadParams.Search) || x.Nombre!.Contains(ciudadParams.Search)
    )
    {
        ApplyPaging(ciudadParams.PageSize * (ciudadParams.PageIndex - 1), ciudadParams.PageSize);

        if (!string.IsNullOrEmpty(ciudadParams.Sort))
        {
            switch (ciudadParams.Sort)
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