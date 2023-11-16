using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Programa : EntidadBase
{
    public string? TipoPrograma { get; set; }    
    public virtual ICollection<Carrera> Carreras { get; set; } = new List<Carrera>();

}