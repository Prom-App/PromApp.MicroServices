using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Plantilla:EntidadBase
{
    public string? Categoria { get; set; }
    public string? Contenido { get; set; }
}