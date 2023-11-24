using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Respuesta:EntidadBase
{
    public string? Enunciado { get; set; }
    public bool Activo { get; set; } = true;
    public int IdPregunta { get; set; }
    public virtual Pregunta? Pregunta { get; set; }
}