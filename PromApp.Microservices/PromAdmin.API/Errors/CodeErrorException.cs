using Newtonsoft.Json;

namespace PromAdmin.API.Errors;

public class CodeErrorException : CodeErrorResponse
{
    [JsonProperty(PropertyName = "detalles")]
    public string? Detalles { get; set; }
    [JsonProperty(PropertyName = "mensajes")]
    public string[]? Mensajes { get; set; }

    public CodeErrorException(int statusCode, string[]? mensajes = null, string? detalles = null)
        : base(statusCode, mensajes)
    {
        Mensajes = mensajes;
        Detalles = detalles;
    }
}