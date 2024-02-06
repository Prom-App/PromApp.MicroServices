using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Habilidad : EntidadBase
{
    public string? NombreHabilidad { get; set; }
    public virtual ICollection<HabilidadXCarrera>? HabilidadesXCarreras { get; set; } 
}