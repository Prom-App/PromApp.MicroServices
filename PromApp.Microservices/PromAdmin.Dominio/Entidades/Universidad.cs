using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Universidad : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Ranking { get; set; }
    public string? Url { get; set; }
    public string? Observaciones { get; set; }
    public bool Privada { get; set; } = true;
    public int IdPais { get; set; }
    public int IdTipoAplicacion { get; set; }
    public int IdAgencia { get; set; }
}