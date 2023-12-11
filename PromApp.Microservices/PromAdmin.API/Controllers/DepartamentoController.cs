using MediatR;
using Microsoft.AspNetCore.Mvc;
using PromAdmin.Core.Componentes.Departamentos.Queries.ListarDepartamentos;
using PromAdmin.Core.Componentes.Departamentos.Queries.PaisPorId;

namespace PromAdmin.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DepartamentoController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartamentoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("listar", Name = "ListarDepartamentos")]
    public async Task<IActionResult> ListarDepartamentos()
    {
        var query = new ListarDepartamentosQuery();
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{id}", Name = "DepartamentoPorId")]
    public async Task<IActionResult> DepartamentoPorId(int id)
    {
        var query = new DepartamentoPorIdQuery(id);
        return Ok(await _mediator.Send(query));
    }
}