namespace PromApp.Mensajeria.Dominio.Entidades.Email;

public class Mensaje
{
    public string? Para { get; set; }
    public string? Asunto { get; set; }
    public string? Cuerpo { get; set; }
    public List<string>? AttachmentsIds { get; set; }
}