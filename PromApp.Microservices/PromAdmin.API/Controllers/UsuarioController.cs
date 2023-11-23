using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.Autenticar;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.Registrar;

namespace PromAdmin.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsuarioController:ControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("autenticar", Name = "autenticar")]
    public async Task<IActionResult> Autenticar(AutenticarUsuarioCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [AllowAnonymous]
    [HttpPost("registrar", Name = "registrar")]
    public async Task<IActionResult> Registrar([FromForm] RegistrarUsuarioCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
}