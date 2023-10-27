using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Carrera : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Url { get; set; }
}