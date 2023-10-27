using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Pais : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Iso2 { get; set; }
}