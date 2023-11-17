using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Specifications.Usuarios;

public class UserSpecification : BaseSpecification<Usuario>
{
    public UserSpecification(UserSpecificationParams userParams) : base(
        x =>
        (
            string.IsNullOrEmpty(userParams.Search) || x.Nombre!.Contains(userParams.Search)
                                                    || x.Email!.Contains(userParams.Search)
        ))
    {
        ApplyPaging(userParams.PageSize * (userParams.PageIndex - 1), userParams.PageSize);

        if (!string.IsNullOrEmpty(userParams.Sort))
        {
            switch (userParams.Sort)
            {
                case "nombreAsc":
                    AddOrderBy(x => x.Nombre!);
                    break;
                case "nombreDesc":
                    AddOrderByDescending(x => x.Nombre!);
                    break;
                case "emailAsc":
                    AddOrderBy(x => x.Email!);
                    break;
                case "emailDesc":
                    AddOrderByDescending(x => x.Email!);
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