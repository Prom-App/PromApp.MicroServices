using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Nacionalidad : EntidadBase
{
    public string? Descripcion { get; set; }
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}