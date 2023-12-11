using MediatR;
using Microsoft.AspNetCore.Mvc;
using PromAdmin.Core.Componentes.Generos.Queries.ListarGeneros;

namespace PromAdmin.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GeneroController : ControllerBase
{
    private readonly IMediator _mediator;

    public GeneroController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("listar", Name = "ListarGeneros")]
    public async Task<IActionResult> ListarGeneros()
    {
        var query = new ListarGenerosQuery();
        return Ok(await _mediator.Send(query));
    }
}