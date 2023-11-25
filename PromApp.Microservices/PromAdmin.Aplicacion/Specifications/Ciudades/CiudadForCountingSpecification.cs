using PromAdmin.Core.Specifications.Usuarios;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Specifications.Ciudades;

public class CiudadForCountingSpecification : BaseSpecification<Ciudad>
{
    public CiudadForCountingSpecification(CiudadSpecificationParams userParams)
        : base(
            x =>
                string.IsNullOrEmpty(userParams.Search) || x.Nombre!.Contains(userParams.Search)
        )
    {
    }
}