using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Evento : EntidadBase
{
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaEvento { get; set; }
    public string? UrlImagen { get; set; }
    public string? UrlReunion { get; set; }
    public bool Activo { get; set; } = true;
}