using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Ciudad : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Iso2 { get; set; }
    public int IdDepartamento { get; set; }
    public int? IdDemografia { get; set; }
}