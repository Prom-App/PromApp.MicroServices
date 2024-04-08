using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Specifications.Eventos;

public class EventForCountingSpecification
    : BaseSpecification<Evento>
{
    public EventForCountingSpecification(EventSpecificationParams eventParams)
        : base(
            x =>
            (
                string.IsNullOrEmpty(eventParams.Search) || x.Titulo!.Contains(eventParams.Search)
                                                         || x.Descripcion!.Contains(eventParams.Search)
            ))
    {
    }
}