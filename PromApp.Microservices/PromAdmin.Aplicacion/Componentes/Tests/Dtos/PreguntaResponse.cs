using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Tests.Dtos;

public class PreguntaResponse
{
    public int Id { get; set; }
    public string? Enunciado { get; set; }
    public int IdTipoPregunta { get; set; }
    public int IdSeccion { get; set; }
    public int IdTest { get; set; }
    public virtual SeccionResponse? Seccion { get; set; }
    public virtual TipoPreguntaResponse? TipoPregunta { get; set; }
    public virtual ICollection<RespuestaResponse>? Respuestas { get; set; }
}