using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class CarreraRelacionada : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Url { get; set; }
    public int IdCarrera { get; set; }
}