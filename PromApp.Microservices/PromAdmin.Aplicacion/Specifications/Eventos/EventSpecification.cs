using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Specifications.Eventos;

public class EventSpecification : BaseSpecification<Evento>
{
    public EventSpecification(EventSpecificationParams eventParams) : base(
        x =>
        (
            string.IsNullOrEmpty(eventParams.Search) || x.Titulo!.Contains(eventParams.Search)
                                                     || x.Descripcion!.Contains(eventParams.Search)
        ))
    {
        ApplyPaging(eventParams.PageSize * (eventParams.PageIndex - 1), eventParams.PageSize);

        if (!string.IsNullOrEmpty(eventParams.Sort))
        {
            switch (eventParams.Sort)
            {
                case "tituloAsc":
                    AddOrderBy(x => x.Titulo!);
                    break;
                case "tituloDesc":
                    AddOrderByDescending(x => x.Titulo!);
                    break;
                case "descripcionAsc":
                    AddOrderBy(x => x.Descripcion!);
                    break;
                case "descripcionDesc":
                    AddOrderByDescending(x => x.Descripcion!);
                    break;
                case "fechaAsc":
                    AddOrderBy(x => x.FechaEvento!);
                    break;
                case "fechaDesc":
                    AddOrderByDescending(x => x.FechaEvento!);
                    break;
                default:
                    AddOrderBy(x => x.FechaEvento!);
                    break;
            }
        }
        else
        {
            AddOrderByDescending(x => x.FechaEvento!);
        }
    }
}