using Newtonsoft.Json;

namespace PromAdmin.API.Errors;

public class CodeErrorResponse
{
    [JsonProperty(PropertyName = "statusCode")]
    public int StatusCode { get; set; }

    [JsonProperty(PropertyName = "mensajes")]
    public string[]? Messages { get; set; }

    public CodeErrorResponse(int statusCode, string[]? messages = null)
    {
        StatusCode = statusCode;
        if (messages != null) Messages = messages;
        Messages = new[] { GetDefaultMessageStatusCode(statusCode) };
    }

    private string GetDefaultMessageStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Petición con errores",
            401 => "No estás autorizado para este recurso",
            404 => "Recurso solicitado no encontrado",
            500 => "Hay un error en el servidor",
            _ => string.Empty
        };
    }
}