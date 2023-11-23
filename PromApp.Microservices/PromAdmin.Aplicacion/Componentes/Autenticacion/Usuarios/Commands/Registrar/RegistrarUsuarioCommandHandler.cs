using MediatR;
using Microsoft.AspNetCore.Identity;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Dtos;
using PromAdmin.Core.Exceptions;
using PromAdmin.Core.Interfaces.Seguridad;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.Registrar;

public class RegistrarUsuarioCommandHandler : IRequestHandler<RegistrarUsuarioCommand, AutenticarResponse>
{
    private readonly UserManager<Usuario> _userManager;
    private readonly IAutenticacionService _autenticacionService;

    public RegistrarUsuarioCommandHandler(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager,
        IAutenticacionService autenticacionService)
    {
        _userManager = userManager;
        _autenticacionService = autenticacionService;
    }

    public async Task<AutenticarResponse> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var buscarUsuario = await _userManager.FindByEmailAsync(request.Email!);
        if (buscarUsuario != null)
            throw new BadRequestException("El correo ya se encuentra registrado");

        var usuario = new Usuario
        {
            Email = request.Email,
            UserName = request.Email
        };

        var result = await _userManager.CreateAsync(usuario, request.Contrasena!);

        if (!result.Succeeded) throw new Exception("No fue posible registrar el usuario");

        //todo: validar token de invitacion que tipo de asociación tiene para asignar el rol

        await _userManager.AddToRoleAsync(usuario, Roles.Freemium.ToString());
        var roles = await _userManager.GetRolesAsync(usuario);
        return new AutenticarResponse
        {
            Id = usuario.Id,
            Email = usuario.Email,
            Token = await _autenticacionService.CrearToken(usuario, roles),
            Roles = roles
        };
    }
}