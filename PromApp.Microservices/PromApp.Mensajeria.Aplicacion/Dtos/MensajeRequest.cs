using Microsoft.AspNetCore.Http;

namespace PromApp.Mensajeria.Aplicacion.Dtos;

public class MensajeRequest
{
    public string? Para { get; set; }
    public string? Asunto { get; set; }
    public string? Cuerpo { get; set; }
    public List<IFormFile> AttachmentsIds { get; set; }
}