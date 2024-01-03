namespace PromAdmin.Core.Componentes.Tests.Dtos;

public class RespuestasRequest
{
    public int IdPregunta { get; set; }
    public string? Pregunta { get; set; }
    public List<int>? IdsRespuesta { get; set; }
    public List<string>? Respuestas { get; set; }
}