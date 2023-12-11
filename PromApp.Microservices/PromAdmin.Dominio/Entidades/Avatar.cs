using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Avatar:EntidadBase
{
    public string? Nombre { get; set; }
    public string? Url { get; set; }
    public virtual ICollection<Usuario>? Usuarios { get; set; }
}