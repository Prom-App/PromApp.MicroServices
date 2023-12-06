namespace PromApp.Mensajeria.Dominio.Entidades.Email;

public class GmailSettings
{
    public string? EmailOrigen { get; set; }
    public string? NombreEtiqueta { get; set; }
    public string? Password { get; set; }
    public string? Servidor { get; set; }
    public int Puerto { get; set; }
}