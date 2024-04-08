namespace PromAdmin.Core.Componentes.Eventos.Dtos;

public class EventoResponse
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaEvento { get; set; }
    public string? UrlImagen { get; set; }
    public string? UrlReunion { get; set; }
    public bool Activo { get; set; }
}