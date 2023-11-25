using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.Autenticar;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.EnviarRestablecimiento;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.Registrar;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.RestablecerContrasena;
using PromAdmin.Core.Componentes.Roles.Queries.ListarRoles;
using PromAdmin.Core.Componentes.Usuarios.Commands.ActualizarUsuario;
using PromAdmin.Core.Componentes.Usuarios.Commands.ActualizarUsuarioAdmin;
using PromAdmin.Core.Componentes.Usuarios.Commands.ActualizarUsuarioEstadoAdmin;
using PromAdmin.Core.Componentes.Usuarios.Queries.PaginacionUsuarios;
using PromAdmin.Core.Componentes.Usuarios.Queries.UsuarioPorId;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("autenticar", Name = "Autenticar")]
    public async Task<IActionResult> Autenticar(AutenticarUsuarioCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [AllowAnonymous]
    [HttpPost("registrar", Name = "Registrar")]
    public async Task<IActionResult> Registrar([FromForm] RegistrarUsuarioCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [AllowAnonymous]
    [HttpPost("olvidarContrasena", Name = "OlvidarContrasena")]
    public async Task<IActionResult> OlvidarContrasena([FromBody] EnviarRestablecimientoCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [AllowAnonymous]
    [HttpPost("restablecerContrasena", Name = "RestablecerContrasena")]
    public async Task<IActionResult> RestablecerContrasena([FromBody] RestablecerContrasenaCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost("actualizarUsuario", Name = "ActualizarUsuario")]
    public async Task<IActionResult> ActualizarUsuario([FromForm] ActualizarUsuarioCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [Authorize(Roles = nameof(ListaRoles.Administrador))]
    [HttpPut("actualizarUsuarioAdmin", Name = "actualizarUsuarioAdmin")]
    public async Task<IActionResult> ActualizarUsuarioAdmin([FromBody] ActualizarUsuarioAdminCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [Authorize(Roles = nameof(ListaRoles.Administrador))]
    [HttpPut("actualizarUsuarioEstadoAdmin", Name = "ActualizarUsuarioEstadoAdmin")]
    public async Task<IActionResult> ActualizarUsuarioEstadoAdmin(
        [FromBody] ActualizarUsuarioEstadoAdminCommandHandler request)
    {
        return Ok(await _mediator.Send(request));
    }

    [Authorize(Roles = nameof(ListaRoles.Administrador))]
    [HttpGet("{id}", Name = "UsuarioPorId")]
    public async Task<IActionResult> UsuarioPorId(string id)
    {
        var query = new UsuarioPorIdQuery(id);
        return Ok(await _mediator.Send(query));
    }

    [Authorize(Roles = nameof(ListaRoles.Administrador))]
    [HttpGet("usuarios", Name = "PaginationUser")]
    public async Task<IActionResult> PaginationUser([FromQuery] PaginacionUsuariosQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [AllowAnonymous]
    [HttpGet("roles", Name = "ListarRoles")]
    public async Task<IActionResult> ListarRoles()
    {
        var query = new ListarRolesQuery();
        return Ok(await _mediator.Send(query));
    }
}