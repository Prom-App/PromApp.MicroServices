using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromAdmin.Core.Componentes.Ciudades.Commands.ActualizarCiudad;
using PromAdmin.Core.Componentes.Ciudades.Commands.CrearCiudad;
using PromAdmin.Core.Componentes.Ciudades.Queries.CiudadPorId;
using PromAdmin.Core.Componentes.Ciudades.Queries.ListarCiudades;
using PromAdmin.Core.Componentes.Ciudades.Queries.PaginacionCiudades;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CiudadController : ControllerBase
{
    private readonly IMediator _mediator;

    public CiudadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("listar", Name = "ListarCiudades")]
    public async Task<IActionResult> ListarCiudades()
    {
        var query = new ListarCiudadesQuery();
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("paginacion", Name = "PaginacionCiudades")]
    public async Task<IActionResult> PaginationProduct([FromQuery] PaginacionCiudadesQuery request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpGet("{id}", Name = "CiudadPorId")]
    public async Task<IActionResult> CiudadPorId(int id)
    {
        var query = new CiudadPorIdQuery(id);
        return Ok(await _mediator.Send(query));
    }

    [Authorize(Roles = nameof(ListaRoles.Administrador))]
    [HttpPost("crear", Name = "CrearCiudad")]
    public async Task<IActionResult> CrearCiudad([FromForm] CrearCiudadCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [Authorize(Roles = nameof(ListaRoles.Administrador))]
    [HttpPost("actualizar", Name = "ActualizarCiudad")]
    public async Task<IActionResult> UpdateProduct([FromForm] ActualizarCiudadCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
}