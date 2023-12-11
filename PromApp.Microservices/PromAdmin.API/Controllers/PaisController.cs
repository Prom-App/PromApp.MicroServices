using MediatR;
using Microsoft.AspNetCore.Mvc;
using PromAdmin.Core.Componentes.Nacionalidades.Queries.ListarNacionalidades;
using PromAdmin.Core.Componentes.Paises.Queries.ListarPaises;
using PromAdmin.Core.Componentes.Paises.Queries.PaisPorId;

namespace PromAdmin.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PaisController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaisController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("listar", Name = "ListarPaises")]
    public async Task<IActionResult> ListarPaises()
    {
        var query = new ListarPaisesQuery();
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{id}", Name = "PaisPorId")]
    public async Task<IActionResult> PaisPorId(int id)
    {
        var query = new PaisPorIdQuery(id);
        return Ok(await _mediator.Send(query));
    }
}