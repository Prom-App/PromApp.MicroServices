using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Aplicacion : EntidadBase
{
    public string? TipoAplicacion { get; set; }
    public virtual ICollection<Universidad> Universidades { get; set; } = new List<Universidad>();
}