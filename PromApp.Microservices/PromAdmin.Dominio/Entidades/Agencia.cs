using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Agencia : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Url { get; set; }
}