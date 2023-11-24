using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Cualidad : EntidadBase
{
    public string? Caracteristica { get; set; }
    public virtual ICollection<CualidadXPersonalidad>? CualidadesXPersonalidad { get; set; }
}