namespace PromAdmin.Core.Models.Token;

public class JwtSettings
{
    public string? Audiencia { get; set; }
    public string? Emisor { get; set; }
    public string? Secreto { get; set; }
    public int Expiracion { get; set; } 
}