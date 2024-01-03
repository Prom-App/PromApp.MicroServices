using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class RespuestaXTest : EntidadBase
{
    public int IdTestUsuario { get; set; }
    public int IdPregunta { get; set; }
    public string? Pregunta { get; set; }
    public string? IdsRespuesta { get; set; }
    public string? Respuesta { get; set; }
    public virtual TestXUsuario? Test { get; set; }
}