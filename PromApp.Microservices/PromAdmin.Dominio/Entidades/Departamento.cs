using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Departamento : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Iso2 { get; set; }
    public int IdPais { get; set; }
}