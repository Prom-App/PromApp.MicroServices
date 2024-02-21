using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromAdmin.Core.Componentes.Tests.Commands.GuardarResultadosTest;
using PromAdmin.Core.Componentes.Tests.Queries.GenerarResultadoPDF;
using PromAdmin.Core.Componentes.Tests.Queries.ObtenerResultadoMBTI;
using PromAdmin.Core.Componentes.Tests.Queries.TestPorNombre;
using PromAdmin.Core.Eventos.MBTI;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;
using PromAdmin.Utilidades.Servicios;

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
    [HttpGet("calcularMBTI", Name = "CalcularMBTI")]
    public async Task<IActionResult> CalcularMBTI()
    {
        var query = new CalcularMBTIEvent
        {
            IdUsuario = "f4c0bf0e-cfc1-4e4e-8e3f-76e4183d8a95",
            IdTestXUsuario = 4,
            Respuestas = await _unitOfWork.Repository<RespuestaXTest>().GetAsync(x => x.IdTestUsuario == 4)
        };
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("resultadoMBTI", Name = "ResultadoMBTI")]
    public async Task<IActionResult> ResultadoMBTI()
    {
        var query = new ObtenerResultadoMBTIQuery();
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("descargarPDF", Name = "DescargarPDF")]
    public async Task<IActionResult> DescargarPDF(GenerarResultadoPdfQuery query)
    {
        return await _mediator.Send(query);
    }
}