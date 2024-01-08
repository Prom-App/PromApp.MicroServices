using PromAdmin.Core.Componentes.Colegios.Dtos;
using PromAdmin.Core.Componentes.Departamentos.Dtos;

namespace PromAdmin.Core.Componentes.Paises.Dtos;

public class PaisResponse
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Iso2 { get; set; }
    public virtual ICollection<DepartamentoResponse>? Departamentos { get; set; }
    public virtual ICollection<ColegioResponse>? Colegios { get; set; }
}