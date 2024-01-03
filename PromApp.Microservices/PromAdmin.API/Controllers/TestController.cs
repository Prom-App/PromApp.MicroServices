using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromAdmin.Core.Componentes.Tests.Commands.GuardarResultadosTest;
using PromAdmin.Core.Componentes.Tests.Queries.TestPorNombre;

namespace PromAdmin.API.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class TestController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet("{nombre}", Name = "TestPorNombre")]
    public async Task<IActionResult> TestPorNombre(string nombre)
    {
        var query = new TestPorNombreQuery(nombre);
        return Ok(await _mediator.Send(query));
    }

    [HttpPost("guardarTest", Name = "GuardarTest")]
    public async Task<IActionResult> GuardarTest(GuardarResultadosTestCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
}