using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Dtos;
using PromAdmin.Core.Componentes.Campus.Dtos;
using PromAdmin.Core.Componentes.Colegios.Dtos;
using PromAdmin.Core.Componentes.Demografias.Dtos;
using PromAdmin.Core.Componentes.Departamentos.Dtos;

namespace PromAdmin.Core.Componentes.Ciudades.Dtos;

public class CiudadResponse
{
    public string? Nombre { get; set; }
    public string? Abreviatura { get; set; }
    public virtual DepartamentoResponse? Departamento { get; set; }
    public virtual DemografiaResponse? Demografia { get; set; }
    public virtual ICollection<ColegioResponse>? Colegios { get; set; }
    public virtual ICollection<AutenticarResponse>? Usuarios { get; set; }
    public virtual ICollection<CampusResponse>? Campus { get; set; }
}