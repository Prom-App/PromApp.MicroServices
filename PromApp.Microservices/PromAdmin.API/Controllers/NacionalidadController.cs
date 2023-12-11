using MediatR;
using Microsoft.AspNetCore.Mvc;
using PromAdmin.Core.Componentes.Nacionalidades.Queries.ListarNacionalidades;

namespace PromAdmin.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class NacionalidadController : ControllerBase
{
    private readonly IMediator _mediator;

    public NacionalidadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("listar", Name = "ListarNacionalidades")]
    public async Task<IActionResult> ListarNacionalidades()
    {
        var query = new ListarNacionalidadesQuery();
        return Ok(await _mediator.Send(query));
    }
}