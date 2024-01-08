using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Pregunta : EntidadBase
{
    public string? Enunciado { get; set; }
    public bool Activo { get; set; } = true;
    public int IdTipoPregunta { get; set; }
    public int IdSeccion { get; set; }
    public int IdTest { get; set; }
    public string? Ayuda { get; set; }
    public string? AyudaGrafica { get; set; }
    public virtual Seccion? Seccion { get; set; }
    public virtual Test? Prueba { get; set; }
    public virtual TipoPregunta? TipoPregunta { get; set; }
    public virtual ICollection<Respuesta>? Respuestas { get; set; }
}