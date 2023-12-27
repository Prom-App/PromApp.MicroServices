using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Tests.Dtos;

public class PreguntaResponse
{
    public int Id { get; set; }
    public string? Enunciado { get; set; }
    public int IdTipoPregunta { get; set; }
    public int IdSeccion { get; set; }
    public int IdTest { get; set; }
    public virtual Seccion? Seccion { get; set; }
    public virtual TipoPregunta? TipoPregunta { get; set; }
    public virtual ICollection<Respuesta>? Respuestas { get; set; }
}