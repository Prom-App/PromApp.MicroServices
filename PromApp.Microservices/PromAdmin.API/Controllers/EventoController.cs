using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromAdmin.Core.Componentes.Eventos.Commands.CrearEvento;
using PromAdmin.Core.Componentes.Eventos.Queries.PaginacionEventos;

namespace PromAdmin.API.Controllers;

public class EventoController: ControllerBase
{
    private readonly IMediator _mediator;

    public EventoController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [AllowAnonymous]
    [HttpPost("crear", Name = "Crear")]
    public async Task<IActionResult> Crear([FromForm] CrearEventoCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    [AllowAnonymous]
    [HttpGet("eventos", Name = "PaginacionEventos")]
    public async Task<IActionResult> PaginacionEventos([FromQuery] PaginacionEventosQuery  request)
    {
        return Ok(await _mediator.Send(request));
    }
}