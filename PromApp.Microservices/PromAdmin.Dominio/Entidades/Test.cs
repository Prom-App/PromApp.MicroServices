using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Test : EntidadBase
{
    public string? NombreTest { get; set; }
    public string? Descripcion { get; set; }
    public string? Observacion { get; set; }
    public bool Activo { get; set; } = true;
    public int? IdModulo { get; set; }
    public virtual Modulo? Modulo { get; set; }
    public virtual ICollection<Seccion>? Secciones { get; set; }
    public virtual ICollection<Pregunta>? Preguntas { get; set; }
    public virtual ICollection<TestXUsuario>? TestsXUsuario { get; set; }
}