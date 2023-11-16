using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Parentesco : EntidadBase
{
    public string? TipoParentesco { get; set; }
    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
}