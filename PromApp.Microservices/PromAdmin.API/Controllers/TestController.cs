using MediatR;
using Microsoft.AspNetCore.Mvc;
using PromAdmin.Core.Componentes.Tests.Queries.TestPorNombre;

namespace PromAdmin.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TestController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{nombre}", Name = "TestPorNombre")]
    public async Task<IActionResult> TestPorNombre(string nombre)
    {
        var query = new TestPorNombreQuery(nombre);
        return Ok(await _mediator.Send(query));
    }
}