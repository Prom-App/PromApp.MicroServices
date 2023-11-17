using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Specifications.Usuarios;

public class UserForCountingSpecification : BaseSpecification<Usuario>
{
    public UserForCountingSpecification(UserSpecificationParams userParams)
        : base(
            x =>
            (
                string.IsNullOrEmpty(userParams.Search) || x.Nombre!.Contains(userParams.Search)
                                                        || x.Email!.Contains(userParams.Search)
            ))
    {
    }
}