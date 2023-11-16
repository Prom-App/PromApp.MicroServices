using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Genero : EntidadBase
{
    public string? TipoGenero { get; set; }
    public string? Saludo { get; set; }
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}