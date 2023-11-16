using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Demografia : EntidadBase
{
    public string? Tamaño { get; set; }
    public virtual ICollection<Ciudad> Ciudades{ get; set; } = new List<Ciudad>();
}