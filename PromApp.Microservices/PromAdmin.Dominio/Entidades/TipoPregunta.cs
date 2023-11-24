using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class TipoPregunta : EntidadBase
{
    public string? Tipo { get; set; }
    public virtual ICollection<Pregunta>? Preguntas { get; set; }
}