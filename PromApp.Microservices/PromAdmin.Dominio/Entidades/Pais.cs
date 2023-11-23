using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Pais : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Iso2 { get; set; }
    public string? Iso3 { get; set; }
    public string? CodigoTelefonico { get; set; }
    public string? Moneda { get; set; }
    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
    public virtual ICollection<Universidad> Universidades { get; set; } = new List<Universidad>();
}