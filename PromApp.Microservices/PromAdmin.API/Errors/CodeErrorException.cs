using Newtonsoft.Json;

namespace PromAdmin.API.Errors;

public class CodeErrorException : CodeErrorResponse
{
    [JsonProperty(PropertyName = "Detalles")]
    public string? Detalles { get; set; }

    public CodeErrorException(int statusCode, string[]? mensajes = null, string? detalles = null)
        : base(statusCode, mensajes)
    {
        Detalles = detalles;
    }
}