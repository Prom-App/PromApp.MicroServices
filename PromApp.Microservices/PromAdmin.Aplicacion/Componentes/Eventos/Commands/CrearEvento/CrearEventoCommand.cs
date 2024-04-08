using MediatR;
using Microsoft.AspNetCore.Http;
using PromAdmin.Core.Componentes.Eventos.Dtos;

namespace PromAdmin.Core.Componentes.Eventos.Commands.CrearEvento;

public class CrearEventoCommand : IRequest<EventoResponse>
{
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaEvento { get; set; }
    public IFormFile? Imagen { get; set; }
    public string? UrlReunion { get; set; }
}