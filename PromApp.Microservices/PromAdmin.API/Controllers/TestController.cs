using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromAdmin.Core.Componentes.Tests.Commands.GuardarResultadosTest;
using PromAdmin.Core.Componentes.Tests.Queries.TestPorNombre;
using PromAdmin.Core.Eventos.MBTI;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.API.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class TestController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;

    public TestController(IMediator mediator, IUnitOfWork unitOfWork)
    {
        _mediator = mediator;
        _unitOfWork = unitOfWork;
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
    
    [AllowAnonymous]
    [HttpGet("CalcularMBTI", Name = "CalcularMBTI")]
    public async Task<IActionResult> CalcularMBTI()
    {
        var query = new CalcularMBTIEvent
        {
            IdUsuario = "7c218340-40c0-4887-969b-7459d5ddd25b",
            IdTestXUsuario = 2,
            Respuestas = await _unitOfWork.Repository<RespuestaXTest>().GetAsync(x => x.IdTestUsuario == 2)
        };
        return Ok(await _mediator.Send(query));
    }
}